using System.IO;
using MyTag.Database;

namespace MyTag
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
            _db = new MongoBase("myDb");
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
        
        private void CopyPicture()
        {
            this._dbName = _db.InsertOnePicture(_name);
            File.Copy(currentPath, FileLocation + this._dbName);
        }
    }
}