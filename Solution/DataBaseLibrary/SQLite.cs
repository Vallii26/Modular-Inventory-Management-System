using System.Data.SQLite;
using CSharpFinal.Adapters;
using Microsoft.Extensions.Configuration;
namespace CSharpFinal.DataBaseLibrary
{
    public class SQLiteAdapter : IDatabaseAdapter
    {
        string? connectionString;
        //Establishes all of the tables from the creation of the adapter
        public SQLiteAdapter()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
            connectionString = config.GetSection("SQLite:ConnectionString").Value;
            createTable("Components", "ID INTEGER PRIMARY KEY AUTOINCREMENT,Name TEXT NOT NULL,Type TEXT,PurchaseDate DATETIME,InstallDate DATETIME,EndOLDate DATETIME,DecommissionedDate DATETIME,updatedDate DATETIME,createdDate DATETIME");
            createTable("Equipment", "ID INTEGER PRIMARY KEY AUTOINCREMENT,Name TEXT NOT NULL,PurchaseDate DATETIME,InstallDate DATETIME,EndOLDate DATETIME,DecommissionedDate DATETIME,updatedDate DATETIME,createdDate DATETIME");
            createTable("CPUCoolers", "ID INTEGER PRIMARY KEY,Description TEXT,FOREIGN KEY(ID) REFERENCES Components(ID)");
            createTable("SSDs", "ID INTEGER PRIMARY KEY,Description TEXT,FOREIGN KEY(ID) REFERENCES Components(ID)");
            createTable("HardDrives", "ID INTEGER PRIMARY KEY,Description TEXT,FOREIGN KEY(ID) REFERENCES Components(ID)");
            createTable("OpticalDiskDrives", "ID INTEGER PRIMARY KEY,Description TEXT,FOREIGN KEY(ID) REFERENCES Components(ID)");
            createTable("PCICables", "ID INTEGER PRIMARY KEY,Description TEXT,FOREIGN KEY(ID) REFERENCES Components(ID)");
            createTable("AudioCables", "ID INTEGER PRIMARY KEY,Description TEXT,FOREIGN KEY(ID) REFERENCES Components(ID)");
            createTable("RamCards", "ID INTEGER PRIMARY KEY,Description TEXT,FOREIGN KEY(ID) REFERENCES Components(ID)");
            createTable("NetworkCards", "ID INTEGER PRIMARY KEY,Description TEXT,FOREIGN KEY(ID) REFERENCES Components(ID)");
            createTable("GraphicCards", "ID INTEGER PRIMARY KEY,Description TEXT,FOREIGN KEY(ID) REFERENCES Components(ID)");
            createTable("Ethernet", "ID INTEGER PRIMARY KEY,Description TEXT,FOREIGN KEY(ID) REFERENCES Components(ID)");
            createTable("PowerStrips", "ID INTEGER PRIMARY KEY,Description TEXT,FOREIGN KEY(ID) REFERENCES Components(ID)");
            createTable("PowerCords", "ID INTEGER PRIMARY KEY,Description TEXT,FOREIGN KEY(ID) REFERENCES Components(ID)");
            createTable("DisplayCables", "ID INTEGER PRIMARY KEY,Description TEXT,FOREIGN KEY(ID) REFERENCES Components(ID)");
        }
        //This method takes in a ComponentData object and adds its values to the Components table and the subtable it belongs to in the database
        public void CreateComponent(ComponentData component)
        {
            component.createdDate = DateTime.Now;
            component.updatedDate = DateTime.Now;
            //This string is where the database will be stored, it is necessary to have so that it connects to the database before executing the SQL commands
            using (var connection = new SQLiteConnection(connectionString))
            {
                //This opens the database and creates the Components table is it hasn't already been created
                connection.Open();
                //And this is where the component is actually added with the values taken from the ComponentData variable that was passed in
                string insertCommand = "INSERT INTO Components (Name,Type,PurchaseDate,InstallDate,EndOLDate,DecommisionedDate,updatedDate,createdDate) VALUES (@name,@componenttype,@purchasedate,@installdate,@endoldate,@decommissioneddate,@updateddate,@createddate);";
                using (var insert = new SQLiteCommand(insertCommand, connection))
                {
                    insert.Parameters.AddWithValue("@name", component.ComponentName);
                    insert.Parameters.AddWithValue("@componenttype", component.SubTableName);
                    insert.Parameters.AddWithValue("@purchasedate", ConvertDateToSQL(component.PurchaseDate));
                    insert.Parameters.AddWithValue("@installationdate", ConvertDateToSQL(component.InstallationDate));
                    insert.Parameters.AddWithValue("@endoldate", ConvertDateToSQL(component.EndOLDate));
                    insert.Parameters.AddWithValue("@decommissioneddate", ConvertDateToSQL(component.DecommissionedDate));
                    insert.Parameters.AddWithValue("@updateddate", ConvertDateToSQL(component.updatedDate));
                    insert.Parameters.AddWithValue("@createddate", ConvertDateToSQL(component.createdDate));
                    insert.ExecuteNonQuery();
                }
                //Gets the Id of the last input so it matches in the subtable
                long lastId;
                using (var idCommand = new SQLiteCommand("SELECT last_insert_rowid()", connection))
                {
                    lastId = (long)idCommand.ExecuteScalar();
                }
                insertCommand = "INSERT INTO " + component.SubTableName + "s (ID, Description) VALUES (" + lastId + ",@description);";
                using (var insert = new SQLiteCommand(insertCommand, connection))
                {
                    insert.Parameters.AddWithValue("@description", component.CompDescriptionType);
                    insert.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        //This method takes in an EquipmentData objects and adds its values to the Equipment table in the database
        public void CreateEquipment(EquipmentData equipment)
        {
            equipment.createdDate = DateTime.Now;
            equipment.updatedDate = DateTime.Now;
            //Same connection string as above so it connects to the same database
            using (var connection = new SQLiteConnection(connectionString))
            {
                //Same purpose as above, but this time for an Equipment table
                connection.Open();
                //Also same as above, but using EquipmentData information
                string insertCommand = "INSERT INTO Equipment (Name,PurchaseDate,InstallationDate,EOLDate,DecommissionedDate,updatedDate,createdDate) VALUES (@name,@purchasedate,@installationdate,@eoldate,@decommissioneddate,@updateddate,@createddate);";
                using (var insert = new SQLiteCommand(insertCommand, connection))
                {
                    insert.Parameters.AddWithValue("@name", equipment.EquipmentName);
                    insert.Parameters.AddWithValue("@purchasedate", ConvertDateToSQL(equipment.PurchaseDate));
                    insert.Parameters.AddWithValue("@installationdate", ConvertDateToSQL(equipment.InstallationDate));
                    insert.Parameters.AddWithValue("@eoldate", ConvertDateToSQL(equipment.EOLDate));
                    insert.Parameters.AddWithValue("@decommissioneddate", ConvertDateToSQL(equipment.DecommissionedDate));
                    insert.Parameters.AddWithValue("@updateddate", ConvertDateToSQL(equipment.updatedDate));
                    insert.Parameters.AddWithValue("@createddate", ConvertDateToSQL(equipment.createdDate));
                    insert.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        //This method removes the Component in the Component table with an ID equivalent to the integer input
        public void DeleteComponent(int compID)
        {
            //Same as above
            using (var connection = new SQLiteConnection(connectionString))
            {
                string type;
                connection.Open();
                string fetchCommand = "SELECT Type FROM Component WHERE ID = " + compID + ";";
                var fetch = new SQLiteCommand(fetchCommand, connection);
                using (var reader = fetch.ExecuteReader())
                {
                    type = reader.GetString(0);
                }
                string deleteCommand = "DELETE FROM Component WHERE ID = " + compID + ";";
                using (var remove = new SQLiteCommand(deleteCommand, connection))
                {
                    remove.ExecuteNonQuery();
                }
                deleteCommand = "DELETE FROM " + type + "s WHERE ID = " + compID + ";";
                using (var remove = new SQLiteCommand(deleteCommand, connection))
                {
                    remove.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        //This method removes the Equipment in the Equipment table with an ID equivalent to the integer input
        public void DeleteEquipment(int equipID)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string deleteCommand = "DELETE FROM Equipment WHERE ID = " + equipID + ";";
                using (var remove = new SQLiteCommand(deleteCommand, connection))
                {
                    remove.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        //This method accesses the database to gather all of the data from all of the Components that are in the Components table.
        //With the data, it creates new ComponentData objects, and adds them to a List of ComponentData objects. It then returns
        //the list when all of the data has been grabbed from the database
        public List<ComponentData> ReadAllComponets()
        {
            List<ComponentData> data = new List<ComponentData>();
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string readAllCommand = "SELECT * FROM Components;";
                var select = new SQLiteCommand(readAllCommand, connection);
                using (var reader = select.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ComponentData added = new ComponentData();
                        added.ComponentID = reader.GetInt32(0);
                        added.ComponentName = reader.GetString(1);
                        added.PurchaseDate = reader.GetDateTime(2);
                        added.InstallationDate = reader.GetDateTime(3);
                        added.EndOLDate = reader.GetDateTime(4);
                        added.DecommissionedDate = reader.GetDateTime(5);
                        added.updatedDate = reader.GetDateTime(6);
                        added.createdDate = reader.GetDateTime(7);
                        data.Add(added);
                    }
                }
                connection.Close();
            }
            return data;
        }

        //This method does the exact same thing as the previous method, but with a List of EquipmentData objects
        //and creation of EquipmentData objects from the data in the Equipment table in the database.
        public List<EquipmentData> ReadAllEquipments()
        {
            List<EquipmentData> data = new List<EquipmentData>();
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string readAllCommand = "SELECT * FROM Equipment;";
                var select = new SQLiteCommand(readAllCommand, connection);
                using (var reader = select.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        EquipmentData added = new EquipmentData();
                        added.EquipmentID = reader.GetInt32(0);
                        added.EquipmentName = reader.GetString(1);
                        added.PurchaseDate = reader.GetDateTime(2);
                        added.InstallationDate = reader.GetDateTime(3);
                        added.EOLDate = reader.GetDateTime(4);
                        added.DecommissionedDate = reader.GetDateTime(5);
                        added.updatedDate = reader.GetDateTime(6);
                        added.createdDate = reader.GetDateTime(7);
                        data.Add(added);
                    }
                }
                connection.Close();
            }
            return data;
        }

        //This method creates and returns a ComponentData object using the data from the Components table in the database where
        //the ID is equivalent to the integer input
        public ComponentData ReadComponent(int compID)
        {
            ComponentData selected = new ComponentData();
            selected.ComponentID = compID;
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string readOneString = "SELECT * FROM Components WHERE ID = " + compID + ";";
                var select = new SQLiteCommand(readOneString, connection);
                using (var reader = select.ExecuteReader())
                {
                    selected.ComponentName = reader.GetString(1);
                    selected.PurchaseDate = reader.GetDateTime(2);
                    selected.InstallationDate = reader.GetDateTime(3);
                    selected.EndOLDate = reader.GetDateTime(4);
                    selected.DecommissionedDate = reader.GetDateTime(5);
                    selected.updatedDate = reader.GetDateTime(6);
                    selected.createdDate = reader.GetDateTime(7);
                }
                connection.Close();
            }
            return selected;
        }

        //This does the same as above, but returns an EquipmentData object made with values from the Equipment table
        public EquipmentData ReadEquipment(int equipID)
        {
            EquipmentData selected = new EquipmentData();
            selected.EquipmentID = equipID;
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string readOneString = "SELECT * FROM Equipment WHERE ID = " + equipID + ";";
                var select = new SQLiteCommand(readOneString, connection);
                using (var reader = select.ExecuteReader())
                {
                    selected.EquipmentName = reader.GetString(1);
                    selected.PurchaseDate = reader.GetDateTime(2);
                    selected.InstallationDate = reader.GetDateTime(3);
                    selected.EOLDate = reader.GetDateTime(4);
                    selected.DecommissionedDate = reader.GetDateTime(5);
                    selected.updatedDate = reader.GetDateTime(6);
                    selected.createdDate = reader.GetDateTime(7);
                }
                connection.Close();
            }
            return selected;
        }

        //This method takes in an integer that finds a distinct Component in the database, and a ComponentData object with values that will
        //replace older values if changes were made to it. It will also automatically update the updateDate as it was just updated.
        public void UpdateComponent(int compID, ComponentData component)
        {
            component.updatedDate = DateTime.Now;
            using (var connection = new SQLiteConnection(connectionString))
            {
                {
                    connection.Open();
                    string updateCommand = "UPDATE Components SET PurchaseDate = @purchasedate,InstallDate = @installationdate,EndOLDate = @endoldate,DecommissionedDate = @decommissioneddate,updatedDate = @updateddate,createdDate = @createddate WHERE ID = " + compID + ";";
                    using (var update = new SQLiteCommand(updateCommand, connection))
                    {
                        update.Parameters.AddWithValue("@purchasedate", ConvertDateToSQL(component.PurchaseDate));
                        update.Parameters.AddWithValue("@installationdate", ConvertDateToSQL(component.InstallationDate));
                        update.Parameters.AddWithValue("@endoldate", ConvertDateToSQL(component.EndOLDate));
                        update.Parameters.AddWithValue("@decommissioneddate", ConvertDateToSQL(component.DecommissionedDate));
                        update.Parameters.AddWithValue("@updateddate", ConvertDateToSQL(component.updatedDate));
                        update.Parameters.AddWithValue("@createddate", ConvertDateToSQL(component.createdDate));
                        update.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }

        }

        //Exact same as above, but with an EquipmentData object and interacting with the Equipment table
        public void UpdateEquipment(int equipID, EquipmentData equipment)
        {
            equipment.updatedDate = DateTime.Now;
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string updateCommand = "UPDATE Equipment SET PurchaseDate = @purchasedate,InstallDate = @installationdate,EOLDate = @endoldate,DecommissionedDate = @decommissioneddate,updatedDate = @updateddate,createdDate = @createddate WHERE ID = " + equipID + ";";
                using (var update = new SQLiteCommand(updateCommand, connection))
                {
                    update.Parameters.AddWithValue("@purchasedate", ConvertDateToSQL(equipment.PurchaseDate));
                    update.Parameters.AddWithValue("@installationdate", ConvertDateToSQL(equipment.InstallationDate));
                    update.Parameters.AddWithValue("@eoldate", ConvertDateToSQL(equipment.EOLDate));
                    update.Parameters.AddWithValue("@decommissioneddate", ConvertDateToSQL(equipment.DecommissionedDate));
                    update.Parameters.AddWithValue("@updateddate", ConvertDateToSQL(equipment.updatedDate));
                    update.Parameters.AddWithValue("@createddate", ConvertDateToSQL(equipment.createdDate));
                    update.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        //Method to convert DateTime values into a string for easy readability for the SQL commands
        public string ConvertDateToSQL(DateTime? Date)
        {
            return Date?.Year + "-" + Date?.Month + "-" + Date?.Day + " " + Date?.Hour + ":" + Date?.Minute + ":" + Date?.Second;
        }

        //Simplifies the process of creating tables in SQLite with multiple varieties of input values
        public void createTable(string TableName, string Properties)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string tableCommand = "CREATE TABLE IF NOT EXISTS " + TableName + " ( " + Properties + " );";
                using (var createTable = new SQLiteCommand(tableCommand, connection))
                {
                    createTable.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public List<ComponentData> ReadAll(string TableName)
        {
            var list = new List<ComponentData>();
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string readCommand = "SELECT Component.ID,Component.Name,Component.PurchaseDate,Component.InstallDate,Component.EndOLDate,Component.DecommisionedDate, Component.updatedDate, Component.createdDate, " + TableName + ".Description FROM " + TableName + ";";
                var select = new SQLiteCommand(readCommand, connection);
                using (var reader = select.ExecuteReader())
                {
                    ComponentData selected = new ComponentData();
                    selected.ComponentID = reader.GetInt32(0);
                    selected.ComponentName = reader.GetString(1);
                    selected.PurchaseDate = reader.GetDateTime(2);
                    selected.InstallationDate = reader.GetDateTime(3);
                    selected.EndOLDate = reader.GetDateTime(4);
                    selected.DecommissionedDate = reader.GetDateTime(5);
                    selected.updatedDate = reader.GetDateTime(6);
                    selected.createdDate = reader.GetDateTime(7);
                    selected.CompDescriptionType = reader.GetString(8);
                    list.Add(selected);
                }
                connection.Close();
            }
            return list;
        }
        public List<ComponentData> ReadRamCards()
        {
            return ReadAll("RamCards");
        }
        public List<ComponentData> ReadCPUCoolers()
        {
            return ReadAll("CPUCoolers");
        }

        public List<ComponentData> ReadSSDs()
        {
            return ReadAll("SSDs");
        }

        public List<ComponentData> ReadHardDrives()
        {
            return ReadAll("HardDrives");
        }

        public List<ComponentData> ReadOpticalDiskDrives()
        {
            return ReadAll("OpticalDiskDrives");
        }

        public List<ComponentData> ReadPCICables()
        {
            return ReadAll("PCICables");
        }

        public List<ComponentData> ReadAudioCables()
        {
            return ReadAll("AudioCables");
        }

        public List<ComponentData> ReadNetworkCards()
        {
            return ReadAll("NetworkCards");
        }

        public List<ComponentData> ReadGraphicCards()
        {
            return ReadAll("GraphicCards");
        }
        public List<ComponentData> ReadEthernet()
        {
            return ReadAll("Ethernet");
        }

        public List<ComponentData> ReadPowerStrips()
        {
            return ReadAll("PowerStrips");
        }

        public List<ComponentData> ReadPowerCords()
        {
            return ReadAll("PowerCords");
        }

        public List<ComponentData> ReadDisplayCables()
        {
            return ReadAll("DisplayCables");
        }
    }
}
