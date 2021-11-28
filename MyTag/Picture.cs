namespace MyTag
{
    public class Picture
    {
        private static string fileLocation = @"C:\MyTag";
        private DB db;
        private string _name;
        private bool isInDB;

        public Picture(string name, bool isInDb = true)
        {
            this._name = name;
            db = new DB();

            if (!isInDb)
            {
                
            }
        }


    }
}