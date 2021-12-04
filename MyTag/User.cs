using System.Runtime.CompilerServices;
using MyTag.Database;

namespace MyTag
{
    public class User
    {
        private UserModel _userModel;

        public User(UserModel userModel)
        {
            _userModel = new UserModel();
        }

    }
}