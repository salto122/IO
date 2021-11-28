namespace MyTag
{
    public class Picture
    {
        private static string fileLocation = @"C:\MyTag";
        private string _name;
        private bool isInDB;

        public Picture(string name, bool isInDb = true)
        {
            this._name = name;

            if (!isInDb)
            {
                //call copy file to fileLocation method
            }
        }
    }
}