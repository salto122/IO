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
        private bool isInDB;

        public Picture(string name, bool isInDb = true)
        {
            this._name = name;
            _db = new DB();

            if (!isInDB)
            {
                this._name = name;
                CopyPicture();
            }
            else
            {
                this._dbName = name;
            }
        }

        private void CopyPicture()
        {
            this._dbName = _db.addFile(_name);
            File.Copy(_currentPath, FileLocation + this._dbName);
        }
    }
}