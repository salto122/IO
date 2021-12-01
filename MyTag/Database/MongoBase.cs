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

        public class PrivateTagsModel
        {
            public string Tags { get; set; }
            public string ExclTags { get; set; }
        }

        public class UserModel
        {
            public Guid guid { get; set; }
            public string Username { get; set; }
            public PrivateTagsModel privateTags { get; set; }
        }

        public class PictureModel
        {
            public Guid guid { get; set; }
            public string OriginalName { get; set; }
            public DateTime AddedDate { get; set; }
            public string Tags { get; set; }
            public string ExclTags { get; set; }
        }
    }
}
