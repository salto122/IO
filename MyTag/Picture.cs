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

        public Picture(string _dbName)
        {
            this._name = _dbName;
            _db = new DB();
        }

        public Picture(string name, string _currentPath)
        {
            this._name = name;
            _db = new DB();
            
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