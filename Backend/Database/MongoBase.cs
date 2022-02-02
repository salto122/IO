 using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Backend.Database.Models;

namespace Backend.Database
{
    public class MongoBase
    {
        public IMongoDatabase db;

        public MongoBase(string databaseName)
        {
            var client = new MongoClient();
            db = client.GetDatabase(databaseName);
        }

        public bool InsertOneUser(string table, UserModel record)
        {
            bool exists = false;
            var collection = db.GetCollection<UserModel>(table);

            var filter = Builders<UserModel>.Filter.Eq("Username", record.Username);

            var user = collection.Find(filter).FirstOrDefault();

            if (user != null && record.Username == user.Username)
            {
                Console.WriteLine("User with that username already exists.");
                exists = true;
                return exists;
            }
            else
            {
                collection.InsertOne(record);
                return exists;
            }
        }

        public void DeleteOneUser(string table, string username)
        {
            var collection = db.GetCollection<UserModel>(table);
            var filter = Builders<UserModel>.Filter.Eq("Username", username);
            collection.DeleteOne(filter);
        }

        public ObjectId InsertOnePicture(string table, PictureModel record)
        {
            record.AddedDate = DateTime.Now;
            var collection = db.GetCollection<PictureModel>(table);

            if (String.IsNullOrWhiteSpace(record.Tags))
            {
                Console.WriteLine("Picture don't have tags.");
                return new ObjectId("000000000000000000000000");
            }

            collection.InsertOne(record);
            return record.Id; // returns ObjectId
        }

        public PictureModel LoadOnePicture(string table, ObjectId id) // search
        {
            var collection = db.GetCollection<PictureModel>(table);
            var filter = Builders<PictureModel>.Filter.Eq("_id", id);

            return collection.Find(filter).First();
        }

        public void UpsertOnePicture(string table, ObjectId id, PictureModel record) //update or insert
        {
            var collection = db.GetCollection<PictureModel>(table);
            var result = collection.ReplaceOne(new BsonDocument("_id", id), record, new ReplaceOptions { IsUpsert = true });
        }

        public void DeleteOnePicture(string table, ObjectId id)
        {

            var collection = db.GetCollection<PictureModel>(table);
            var filter = Builders<PictureModel>.Filter.Eq("_id", id);

            collection.DeleteOne(filter);
        }

        public List<PictureModel> LoadPictures(string table)
        {
            var collection = db.GetCollection<PictureModel>(table);

            return collection.Find(new BsonDocument()).ToList();
        }
    }
}
