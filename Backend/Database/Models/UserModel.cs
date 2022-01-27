
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Backend.Database.Models
{
    public class UserModel
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Username { get; set; }
        public string Tags { get; set; }
        private User Users { get; set; }

        public UserModel(string username, string tags)
        {
            Username = username;
            Tags = tags;
            Users = new User();
        }

        public UserModel CreateUser()
        {
            Users.AddUser(new UserModel(Username, Tags));
            return new UserModel(Username, Tags);
        }
    }
}
