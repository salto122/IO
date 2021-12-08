
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MyTag.Database
{
    public class UserModel
    {
        public UserModel(string username, string tags)
        {
            Username = username;
            Tags = tags;
        }

        [BsonId]
        public ObjectId Id { get; set; }
        public string Username { get; set; }
        public string Tags { get; set; }
    }
}
