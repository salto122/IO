using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTag.Database
{
    public class MongoConnection
    {
        IMongoDatabase db;
        public MongoConnection(string databaseName)
        {
            var client = new MongoClient();
            db = client.GetDatabase(databaseName);
        }
    }
}
