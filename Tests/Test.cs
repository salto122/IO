using Backend;
using Backend.Database;
using Backend.Database.Models;
using MongoDB.Bson;
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


    }
}