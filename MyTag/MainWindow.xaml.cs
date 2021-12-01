﻿using MyTag.Database;
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
                privateTags = new PrivateTagsModel
                {
                    Tags = "#meme, #car, #funny",
                    ExclTags = "#motorcycle, #notfunny"
                }
            };



            db.InsertOneUser("users", user);
        }
    }
}