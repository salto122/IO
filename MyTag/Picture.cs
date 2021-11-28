using System.IO;

namespace MyTag
{
    public class Picture
    {
        private static string fileLocation = @"C:\MyTag\";
        private DB _db;
        private string _name;
        private string _dbName;
        private string _currentPath;
        private bool isInDB;

        public Picture(string name, bool isInDb = true)
        {
            this._name = name;
            _db = new DB();

            if (!isInDb)
            {
                CopyPicture();
            }
        }

        private void CopyPicture()
        {
            this._dbName = _db.addFile(_name);
            File.Copy(_currentPath, fileLocation + this._dbName);
        }
    }
}