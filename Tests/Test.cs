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
        public void DoesAddValueWork()
        {
            Assert.AreEqual(new ObjectId("000000000000000000000000"), dbTest.InsertOnePicture("pictures", new PictureModel("empty", "")));

            var user = dbTest.InsertOneUser("users", new UserModel("Anny", ""));


        }
    }
}