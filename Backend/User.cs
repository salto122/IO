using Backend.Database.Models;
using Backend.Database;

namespace Backend
{
    public class User
    {
        private readonly UserModel _userModel;
        private readonly MongoBase _db;

        public User(UserModel userModel)
        {
            _userModel = userModel;
        }

        public bool AddUser(string username)
        {
            return _db.InsertOneUser("Users", new UserModel(username, "")); // returns bool to check if that username exists
        }

        

        public string GetUserName()
        {
            return _userModel.Username;
        }
    }
}