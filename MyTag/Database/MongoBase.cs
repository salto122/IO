using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace MyTag.Database
{
    public class MongoBase
    {
        IMongoDatabase db;
        public MongoBase(string databaseName)
        {
            var client = new MongoClient();
            db = client.GetDatabase(databaseName);
        }

        public void InsertOneUser(string table, UserModel record)
        {
            var collection = db.GetCollection<UserModel>(table);
            collection.InsertOne(record);

            
        }

        public string InsertOnePicture(string table, PictureModel record)
        {
            record.AddedDate = DateTime.Now;
            var collection = db.GetCollection<PictureModel>(table);
            collection.InsertOne(record);

            return record.Id.ToString();
        }

        public List<T> LoadAll<T>(string table)
        {
            var collection = db.GetCollection<T>(table);

            return collection.Find(new BsonDocument()).ToList();
        }
    }
}
