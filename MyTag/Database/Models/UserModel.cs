
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MyTag.Database
{
    public class UserModel
    {
        [BsonId]
        public Guid guid { get; set; }
        public string Username { get; set; }
        public PrivateTagsModel privateTags { get; set; }
    }
}
