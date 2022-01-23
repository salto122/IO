using Backend;
using Backend.Database;
using Backend.Database.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using NUnit.Framework;

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
        public void DoesDeleteOnePictureWork()
        {
            ObjectId objectId = new ObjectId("61b9fed3f61bb7bfa09d7e41");

            dbTest.DeleteOnePicture("pictures", objectId);

            var collection = dbTest.db.GetCollection<PictureModel>("pictures");
            var filter = Builders<PictureModel>.Filter.Eq("_id", objectId);

            Assert.IsNull(collection.Find(filter).FirstOrDefault());
        }
        
        [TestCase]
        public void DoesUserClassMethodsWork()
        {
            User user = new User();
            
            Assert.IsFalse(user.AddUser("test_user"));
            Assert.IsTrue(user.AddUser("test_user"));
            
            user.DeleteUser("test_user");
        }
    }
}