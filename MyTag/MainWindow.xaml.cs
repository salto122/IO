using MyTag.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace MyTag
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MongoBase db = new MongoBase("testconnection");

            UserModel user = new UserModel
            {
                Username = "Joe",
                Tags = "#meme, #car, #funny",

            };

            PictureModel picture = new PictureModel
            {
                OriginalName = "oryginalna2 nazwa",
                Tags = "#car, #kek",
            };


            string testowystring = db.InsertOnePicture("pictures", picture);

            db.InsertOneUser("users", user);


        }
    }
}