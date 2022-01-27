using Backend.Database.Models;
using Backend.Database;

namespace Backend
{
    public class User
    {
        private readonly UserModel _userModel;
        private readonly MongoBase _db;

        public User()
        {
            _db = new MongoBase(MongoConnection.conMethod());
        }


        public bool AddUser(string username)
        {
            return _db.InsertOneUser("Users", new UserModel(username, "")); // returns bool to check if that username exists
        }

        public void DeleteUser(string username)
        {
            _db.DeleteOneUser("Users", username);
        }

        public string GetUserName()
        {
            return _userModel.Username;
        }
    }
}