
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MyTag.Database
{
    public class UserModel
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Username { get; set; }
        public string Tags { get; set; }
    }
}
