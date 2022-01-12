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

        public void AddUser(string username)
        {
            _db.InsertOneUser("Users", new UserModel(username, ""));
        }

        public string GetUserName()
        {
            return _userModel.Username;
        }
    }
}