using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;




namespace MyTag.ExtraWIndows
{
    /// <summary>
    /// Logika interakcji dla klasy SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public enum PathType
        {
            SaveFolderPath,
            SearchFolderPath
        }
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void BT_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BT_Save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BT_SetSaveImagePath_Click(object sender, RoutedEventArgs e)
        {
            SetFolderPath(PathType.SaveFolderPath);
        }

        private void BT_SetSearchImagePath_Click(object sender, RoutedEventArgs e)
        {
            SetFolderPath(PathType.SearchFolderPath);
        }

        public void SetFolderPath(PathType setting)
        {
            using (var openFolderDialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = openFolderDialog.ShowDialog();
                switch (setting)
                {
                    case PathType.SaveFolderPath:
                        TBImageFolderPath.Text = openFolderDialog.SelectedPath;
                        break;
                    case PathType.SearchFolderPath:
                        TBSerachImageFolderPath.Text = openFolderDialog.SelectedPath;
                        break;
                }
            }
        }
    }
}
