//using MongoDB.Driver;
//using MongoDB.Bson;
//using CSharpFinal.Adapters;
//using Microsoft.Extensions.Configuration;

//namespace CSharpFinal.DataBaseLibrary
//{
//    public class Mongo : IDatabaseAdapter
//    {
//        private readonly MongoClient _client;
//        private readonly IMongoDatabase _database;

//        public Mongo()
//        {
//            // Build a config object, using env vars and JSON providers.
//            IConfigurationRoot config = new ConfigurationBuilder()
//                .AddJsonFile("appsettings.json")
//                .AddEnvironmentVariables()
//                .Build();

//            var connectionString = config.GetSection("MongoDB:ConnectionString").Value;
//            var databaseName = config.GetSection("MongoDB:DatabaseName").Value;

//            //var connectionString = Environment.GetEnvironmentVariable("MONGODB_ENV");
//            // You must set your 'MONGODB_URI' environment variable. To learn how to set it, see https://www.mongodb.com/docs/drivers/csharp/current/quick-start/#set-your-connection-string
//            _client = new MongoClient(connectionString);
//            _database = _client.GetDatabase(databaseName);
//        }
        
//        public void CreateComponent(ComponentData component)
//        {
//            //create component
//            var collection = GetComponentCollection("Component");
//            collection.InsertOne( {
//                    id: component.EquipmentID,
//                    name: component.ComponentName,
//                    purchaseDate: component.PurchaseDate,
//                    installDate: component.InstallationDate,
//                    eolDate: component.EOLDate,
//                    decomissionedDate: component.DecodmmissionedDate,
//                    updatedDate: component.updatedDate,
//                    createdDate: component.createdDate,
//                    category: component.SubTableName,
//                    details: component.CompDescriptionType
//                    }
//            )
//        }

//        public void CreateEquipment(EquipmentData equipment)
//        {
//            var collection = GetComponentCollection("Equipment");
//            collection.InsertOne( {
//                    id: equipment.EquipmentID, 
//                    name: equipment.EquipmentName, 
//                    purchaseDate: equipment.PurchaseDate, 
//                    installDate: equipment.InstallationDate, 
//                    eolDate: equipment.EOLDate, 
//                    decomissionedDate: equipment.DecodmmissionedDate, 
//                    updatedDate: equipment.updatedDate, 
//                    createdDate: equipment.createdDate,
//                    //extract the component IDs from the object and store them in a list in mongo
//                    componentlist: equipment.Components?.Select(c => c.ComponentID).ToList()
//                    } 
//            )
//        }

//        public void DeleteComponent(int compID) 
//        {
//            var collection = GetComponentCollection("Component");
//            collection.DeleteOne( {id: ObjectId(compID) } ); //might need to remove ObjectId() This could refer to the _id
//        }

//        public void DeleteEquipment(int equipID)
//        {
//            var collection = GetComponentCollection("Equipment");
//            collection.DeleteOne( { id: ObjectId(equipID) } ); //might need to remove ObjectId() This could refer to the _id
//        }

//        public List<ComponentData> ReadAllComponets()
//        {
//            var collection = GetComponentCollection("Component");
//            return collection.Find(new BsonDocument()).ToList();
//        }

//        public List<EquipmentData> ReadAllEquipments()
//        {
//            var collection = GetEquipmentCollection("Equipment");
//            return collection.Find(new BsonDocument()).ToList();
//        }

//        public ComponentData ReadComponent(int compID)
//        {
//            var collection = GetComponentCollection();
//            return collection.FindOne(
//            { id: compID}
//            );
            
//        }

//        public EquipmentData ReadEquipment(int equipID)
//        {
//            var collection = GetComponentCollection();
//            return collection.FindOne(
//            { id: compID}
//            );
//        }

//        public void UpdateComponent(int compID, ComponentData component)
//        {
//            //delete component
//            var collection = GetComponentCollection("Component");
//            collection.DeleteOne( { id: ObjectId(compID) } ); //might need to remove ObjectId() This could refer to the _id
//            //create component
//            collection.InsertOne( {
//                id: component.EquipmentID,
//                name: component.ComponentName,
//                purchaseDate: component.PurchaseDate,
//                installDate: component.InstallationDate,
//                eolDate: component.EOLDate,
//                decomissionedDate: component.DecodmmissionedDate,
//                updatedDate: component.updatedDate,
//                createdDate: component.createdDate,
//                category: component.SubTableName,
//                details: component.CompDescriptionType
//                }
//            )
//        }

//        public void UpdateEquipment(int equipID, EquipmentData equipment)
//        {
//            //delete component
//            var collection = GetComponentCollection("Component");
//            collection.DeleteOne( { id: ObjectId(compID) } ); //might need to remove ObjectId() This could refer to the _id
//            //create equipment
//            var collection = GetComponentCollection("Equipment");
//            collection.InsertOne( {
//                id: equipment.EquipmentID, 
//                name: equipment.EquipmentName, 
//                purchaseDate: equipment.PurchaseDate, 
//                installDate: equipment.InstallationDate, 
//                eolDate: equipment.EOLDate, 
//                decomissionedDate: equipment.DecodmmissionedDate, 
//                updatedDate: equipment.updatedDate, 
//                createdDate: equipment.createdDate,
//                //extract the component IDs from the object and store them in a list in mongo
//                componentlist: equipment.Components?.Select(c => c.ComponentID).ToList()
//                } 
//            )
//        }
//    }
//}
