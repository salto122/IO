using System.IO;

namespace MyTag
{
    public class Picture
    {
        private const string FileLocation = @"C:\MyTag\";
        private DB _db;
        private readonly string _name;
        private string _dbName;
        private string _currentPath;
        
        public Picture()
        {
            _db = new DB();
        }        
        
        public Picture(string _dbName) : this()
        {
            this._name = _dbName;
        }

        public Picture(string name, string _currentPath) : this()
        {
            this._name = name;
            CopyPicture();
        }        
        
        private void CopyPicture()
        {
            this._dbName = _db.addFile(_name);
            File.Copy(_currentPath, FileLocation + this._dbName);
        }
    }
}