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
using System.Windows.Shapes;
using System.Diagnostics;

namespace MyTag.ExtraWIndows
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    /// 

    public partial class AddTagWindow : Window
    {
        public static bool AddTagStatusCaneled = false;

        public AddTagWindow()
        {
            InitializeComponent();
        }

        private void BT_SetTag_Click(object sender, RoutedEventArgs e)
        {
            if (!(String.IsNullOrEmpty(TB_AddTags.Text.ToString())) && !(String.IsNullOrWhiteSpace(TB_AddTags.Text.ToString())))
            {
                MainWindow.ImportedImageTags = TB_AddTags.Text.ToString();
            }
            else
            {
                TB_AddTags.Text = "#empty";
                MainWindow.ImportedImageTags = TB_AddTags.Text;
            }
            Close();
        }


        private void BT_CancelTag_Click(object sender, RoutedEventArgs e)
        {
            AddTagStatusCaneled = true;
            Debug.WriteLine("AddTagStatusCaneled: " + AddTagStatusCaneled);
            Close();
        }
    }
}
