using Backend.Database.Models;

namespace Backend
{
    public class User
    {
        private readonly UserModel _userModel;

        public User(UserModel userModel)
        {
            _userModel = userModel;
        }

        public void SetUserName(string username)
        {
            _userModel.Username = username;
        }

        public string GetUserName()
        {
            return _userModel.Username;
        }
    }
}