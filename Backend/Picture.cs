using Backend.Database;
using System;

namespace Backend
{
    public class Picture
    {
        private const string FileLocation = @"C:\MyTag\";
        private MongoBase _db;
        private readonly string _name;
        private string _dbName;
        private string currentPath;
        
        public Picture()
        {
            _db = MongoBase.getDB();
        }        
        
        public Picture(string dbName) : this()
        {
            this._name = dbName;
        }

        public Picture(string name, string currentPath) : this()
        {
            this._name = name;
            this.currentPath = currentPath;
            CopyPicture();
        }        
        
        public void CopyPicture()
        {
            //this._dbName = _db.InsertOnePicture("table_name", new PictureModel(_name, "tags"));
            //File.Copy(currentPath, FileLocation + this._dbName);

            //var objectid = _db.InsertOnePicture("pictures", new Database.Models.PictureModel("not empty", "#notempty"));
            //System.Console.WriteLine(objectid.ToString());

            //var rec = _db.LoadOnePicture("pictures", new MongoDB.Bson.ObjectId("61b9fed3f61bb7bfa09d7e41"));
            //rec.Tags = "#doge, #car, #cute";
            //_db.UpsertOnePicture("pictures", rec.Id, rec);

            //var test = rec.Tags.ToString();
            //System.Console.WriteLine(test);

            //_db.InsertOneUser("users", new Database.Models.UserModel("Anny", ""));
        }

        public string SetName(string filename)
        {
            var objectid = _db.InsertOnePicture("Pictures", new Database.Models.PictureModel(filename, "#empty"));

            return objectid.ToString();
        }

        public string SetNameAndTags(string filename, string tags)
        {
            var objectid = _db.InsertOnePicture("Pictures", new Database.Models.PictureModel(filename, tags));

            return objectid.ToString();
        }

        public string? GetTag(string filename)
        {
            try
            {
                var record = _db.LoadOnePicture("Pictures", new MongoDB.Bson.ObjectId($"{filename}"));
                return record.Tags;
            }
            catch
            {
                return null;
            }

        }
    }
}