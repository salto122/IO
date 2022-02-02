using Backend;
using Backend.Database;
using Backend.Database.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using NUnit.Framework;
using System.Linq;
using System.Diagnostics;


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
    }
    [TestFixture]
    public class TestyMarcinka
    {
        private MongoBase dbTest = new MongoBase(MongoConnection.DatabaseName);
        Picture tempPicture = new Picture();

        [TestCase]
        public void ImageNotExistInDataBase()
        {
            Assert.IsNull(tempPicture.GetTag("66fabd55a725255d65931b82"));//b³êdny ObjectID
        }

        [TestCase]
        public void ImageExistInDataBase()
        {
            Assert.IsNotNull(tempPicture.GetTag("61fabd55a725255d65931b82"));
        }

        [TestCase]
        public void CompareTags()
        {
            string tag = "#empty";
            tempPicture.SetNameAndTags("22fabd55a725255d65931b82", tag);
            Assert.AreEqual(tempPicture.GetTag("22fabd55a725255d65931b82"), tempPicture.GetTag("22fabd55a725255d65931b82"));
        }

    }
}