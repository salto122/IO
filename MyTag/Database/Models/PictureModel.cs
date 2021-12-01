using System;
using MongoDB.Bson.Serialization.Attributes;

namespace MyTag.Database
{
    public class PictureModel
    {
        [BsonId]
        public Guid guid { get; set; }
        public string OriginalName { get; set; }
        public DateTime AddedDate { get; set; }
        public string Tags { get; set; }
        public string ExclTags { get; set; }
    }
}
