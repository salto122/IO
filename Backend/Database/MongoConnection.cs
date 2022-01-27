using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Database
{
    class MongoConnection
    {
        public string Value { get; set; }
        private static string DBname = "MyTag";
        private static MongoConnection instance;
        private static readonly object _lock = new object();

        private MongoConnection() { }
        private static MongoConnection getInstance()
        {
            if (MongoConnection.instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new MongoConnection();
                        instance.Value = DBname;
                    }
                }
            }
            return instance;
        }

        
    }
}
