using System;

namespace Backend
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Picture picture = new Picture();

            picture.CopyPicture();

            User user = new User();

            var test = user.AddUser("Mat");
            user.DeleteUser("Mat");

        }
    }
}