using Backend;
using Backend.Database;
using Backend.Database.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using NUnit.Framework;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class TestClassTest
    {
        private MongoBase dbTest = new MongoBase(MongoConnection.DatabaseName);

        [TestCase]
        public void DoesPictureHaveTags()
        {
            Assert.AreEqual(new ObjectId("000000000000000000000000"), dbTest.InsertOnePicture("pictures", new PictureModel("empty", "")));
        }

        [TestCase]
        public void DoesUserExists()
        {
            var user = dbTest.InsertOneUser("users", new UserModel("Anny", ""));
            Assert.IsTrue(user);
        }
        [TestCase]
        public void DidPictureGotDeleted()
        {
            ObjectId objectId = new ObjectId("61d882281218c7afcf9d9995");

            var collection = dbTest.db.GetCollection<PictureModel>("pictures");
            var filter = Builders<PictureModel>.Filter.Eq("_id", objectId);

            var test = collection.Find(filter).FirstOrDefault();
            
            Assert.IsTrue(test.Id == objectId);
        }
    }
}