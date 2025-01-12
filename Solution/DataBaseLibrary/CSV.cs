using CSharpFinal.Adapters;
using Microsoft.Extensions.Configuration;
using CsvHelper;

namespace CSharpFinal.DataBaseLibrary
{
    public class CSVAdapter : IDatabaseAdapter
    {
        private readonly string _folderPath;

        public CSVAdapter()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            _folderPath = config["CSVFolderPath"] ?? @"C:\Users\Cameron\Desktop\DatabaseCSVFolder";

            if (!Directory.Exists(_folderPath))
            {
                Directory.CreateDirectory(_folderPath);
                Console.WriteLine($"Folder created at: {_folderPath}");
            }
        }

        private void EnsureCSVFileExists(string fileName, string headers)
        {
            string filePath = Path.Combine(_folderPath, fileName + ".csv");
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, headers + Environment.NewLine);
            }
        }

        public void CreateComponent(ComponentData component)
        {
            EnsureCSVFileExists("Components", "ID,Name,Type,PurchaseDate,InstallDate,EndOLDate,DecommissionedDate,UpdatedDate,CreatedDate");

            string filePath = Path.Combine(_folderPath, "Components.csv");
            var line = $"{component.ComponentID},{component.ComponentName},{component.SubTableName},{ConvertDateToCSV(component.PurchaseDate)},{ConvertDateToCSV(component.InstallationDate)},{ConvertDateToCSV(component.EndOLDate)},{ConvertDateToCSV(component.DecommissionedDate)},{ConvertDateToCSV(component.updatedDate)},{ConvertDateToCSV(component.createdDate)}";
            File.AppendAllText(filePath, line + Environment.NewLine);
        }

        public void CreateEquipment(EquipmentData equipment)
        {
            EnsureCSVFileExists("Equipment", "ID,Name,PurchaseDate,InstallDate,EOLDate,DecommissionedDate,UpdatedDate,CreatedDate");

            string filePath = Path.Combine(_folderPath, "Equipment.csv");
            var line = $"{equipment.EquipmentID},{equipment.EquipmentName},{ConvertDateToCSV(equipment.PurchaseDate)},{ConvertDateToCSV(equipment.InstallationDate)},{ConvertDateToCSV(equipment.EOLDate)},{ConvertDateToCSV(equipment.DecommissionedDate)},{ConvertDateToCSV(equipment.updatedDate)},{ConvertDateToCSV(equipment.createdDate)}";
            File.AppendAllText(filePath, line + Environment.NewLine);
        }

        public void DeleteComponent(int compID)
        {
            string filePath = Path.Combine(_folderPath, "Components.csv");
            var lines = File.ReadAllLines(filePath);

            using (var writer = new StreamWriter(filePath))
            {
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (int.Parse(parts[0]) != compID) // If the line does not match the ID, keep it
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }

        public void DeleteEquipment(int equipID)
        {
            string filePath = Path.Combine(_folderPath, "Equipment.csv");
            var lines = File.ReadAllLines(filePath);

            using (var writer = new StreamWriter(filePath))
            {
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (int.Parse(parts[0]) != equipID) // If the line does not match the ID, keep it
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }

        public List<ComponentData> ReadAllComponets()
        {
            string filePath = Path.Combine(_folderPath, "Components.csv");
            var lines = File.ReadAllLines(filePath);
            var components = new List<ComponentData>();

            foreach (var line in lines)
            {
                var parts = line.Split(',');
                var component = new ComponentData
                {
                    ComponentID = int.Parse(parts[0]),
                    ComponentName = parts[1],
                    SubTableName = parts[2],
                    PurchaseDate = DateTime.Parse(parts[3]),
                    InstallationDate = DateTime.Parse(parts[4]),
                    EndOLDate = DateTime.Parse(parts[5]),
                    DecommissionedDate = DateTime.Parse(parts[6]),
                    updatedDate = DateTime.Parse(parts[7]),
                    createdDate = DateTime.Parse(parts[8])
                };
                components.Add(component);
            }

            return components;
        }

        public List<EquipmentData> ReadAllEquipments()
        {
            string filePath = Path.Combine(_folderPath, "Equipment.csv");
            var lines = File.ReadAllLines(filePath);
            var equipments = new List<EquipmentData>();

            foreach (var line in lines)
            {
                var parts = line.Split(',');
                var equipment = new EquipmentData
                {
                    EquipmentID = int.Parse(parts[0]),
                    EquipmentName = parts[1],
                    PurchaseDate = DateTime.Parse(parts[2]),
                    InstallationDate = DateTime.Parse(parts[3]),
                    EOLDate = DateTime.Parse(parts[4]),
                    DecommissionedDate = DateTime.Parse(parts[5]),
                    updatedDate = DateTime.Parse(parts[6]),
                    createdDate = DateTime.Parse(parts[7])
                };
                equipments.Add(equipment);
            }

            return equipments;
        }

        public ComponentData ReadComponent(int compID)
        {
            ComponentData componentData = new ComponentData();
            string filePath = Path.Combine(_folderPath, "Components.csv");
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (int.Parse(parts[0]) == compID)
                {
                    return new ComponentData
                    {
                        ComponentID = int.Parse(parts[0]),
                        ComponentName = parts[1],
                        SubTableName = parts[2],
                        PurchaseDate = DateTime.Parse(parts[3]),
                        InstallationDate = DateTime.Parse(parts[4]),
                        EndOLDate = DateTime.Parse(parts[5]),
                        DecommissionedDate = DateTime.Parse(parts[6]),
                        updatedDate = DateTime.Parse(parts[7]),
                        createdDate = DateTime.Parse(parts[8]),
                    };
                }
            }

            return componentData; // or throw exception if not found
        }

        public EquipmentData ReadEquipment(int equipID)
        {
            string filePath = Path.Combine(_folderPath, "Equipment.csv");
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (int.Parse(parts[0]) == equipID)
                {
                    return new EquipmentData
                    {
                        EquipmentID = int.Parse(parts[0]),
                        EquipmentName = parts[1],
                        PurchaseDate = DateTime.Parse(parts[2]),
                        InstallationDate = DateTime.Parse(parts[3]),
                        EOLDate = DateTime.Parse(parts[4]),
                        DecommissionedDate = DateTime.Parse(parts[5]),
                        updatedDate = DateTime.Parse(parts[6]),
                        createdDate = DateTime.Parse(parts[7])
                    };
                }
            }

            return null; // or throw exception if not found
        }

        public void UpdateComponent(int compID, ComponentData component)
        {
            string filePath = Path.Combine(_folderPath, "Components.csv");
            var lines = File.ReadAllLines(filePath);
            using (var writer = new StreamWriter(filePath))
            {
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (int.Parse(parts[0]) == compID)
                    {
                        var updatedLine = $"{component.ComponentID},{component.ComponentName},{component.SubTableName},{ConvertDateToCSV(component.PurchaseDate)},{ConvertDateToCSV(component.InstallationDate)},{ConvertDateToCSV(component.EndOLDate)},{ConvertDateToCSV(component.DecommissionedDate)},{ConvertDateToCSV(component.updatedDate)},{ConvertDateToCSV(component.createdDate)}";
                        writer.WriteLine(updatedLine);
                    }
                    else
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }

        public void UpdateEquipment(int equipID, EquipmentData equipment)
        {
            string filePath = Path.Combine(_folderPath, "Equipment.csv");
            var lines = File.ReadAllLines(filePath);
            using (var writer = new StreamWriter(filePath))
            {
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (int.Parse(parts[0]) == equipID)
                    {
                        var updatedLine = $"{equipment.EquipmentID},{equipment.EquipmentName},{ConvertDateToCSV(equipment.PurchaseDate)},{ConvertDateToCSV(equipment.InstallationDate)},{ConvertDateToCSV(equipment.EOLDate)},{ConvertDateToCSV(equipment.DecommissionedDate)},{ConvertDateToCSV(equipment.updatedDate)},{ConvertDateToCSV(equipment.createdDate)}";
                        writer.WriteLine(updatedLine);
                    }
                    else
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }

        private string ConvertDateToCSV(DateTime? date)
        {
            return date.HasValue ? date.Value.ToString("yyyy-MM-dd HH:mm:ss") : string.Empty;
        }
    }
}