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
            _db = MongoBase.getDB();
        }
        
        public bool AddUser(UserModel username)
        {
            return _db.InsertOneUser("Users", _userModel.CreateUser()); // returns bool to check if that username exists
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