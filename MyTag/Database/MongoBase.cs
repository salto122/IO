using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void InsertOne<T>(string table, T record)
        {
            var collection = db.GetCollection<T>(table);
            collection.InsertOne(record);
        }

        public List<T> LoadAll<T>(string table)
        {
            var collection = db.GetCollection<T>(table);

            return collection.Find(new BsonDocument()).ToList();
        }
    }
}
