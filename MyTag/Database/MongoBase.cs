﻿using MongoDB.Bson;
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

        public void DeleteOneUser(string table, ObjectId id)
        {
            var collection = db.GetCollection<UserModel>(table);
            var filter = Builders<UserModel>.Filter.Eq("_id", id);
            collection.DeleteOne(filter);
        }

        public ObjectId InsertOnePicture(string table, PictureModel record)
        {
            record.AddedDate = DateTime.Now;
            var collection = db.GetCollection<PictureModel>(table);
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