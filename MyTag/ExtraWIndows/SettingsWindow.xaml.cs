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
using System.Configuration;
using MyTag.Properties;


namespace MyTag.ExtraWIndows
{
    /// <summary>
    /// Logika interakcji dla klasy SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public enum PathType
        {
            StoreImagePath,
            SearchImagerPath
        }
        public SettingsWindow()
        {
            InitializeComponent();

            TBImageFolderPath.Text = Settings.Default.StorePath.ToString();
            TBSerachImageFolderPath.Text = Settings.Default.SearchPath.ToString();
        }

        private void BT_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BT_Save_Click(object sender, RoutedEventArgs e)
        {
            Settings.Default.StorePath = TBImageFolderPath.Text;
            Settings.Default.Save();
            Settings.Default.SearchPath = TBSerachImageFolderPath.Text;
            Settings.Default.Save();
            Settings.Default.Upgrade();
            MessageBox.Show("Saved Settings");
            
        }

        private void BT_SetSaveImagePath_Click(object sender, RoutedEventArgs e)
        {
            SetFolderPath(PathType.StoreImagePath);
        }

        private void BT_SetSearchImagePath_Click(object sender, RoutedEventArgs e)
        {
            SetFolderPath(PathType.SearchImagerPath);
        }

        public void SetFolderPath(PathType setting)
        {
            using (var openFolderDialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = openFolderDialog.ShowDialog();
                switch (setting)
                {
                    case PathType.StoreImagePath:
                        TBImageFolderPath.Text = openFolderDialog.SelectedPath;
                        break;
                    case PathType.SearchImagerPath:
                        TBSerachImageFolderPath.Text = openFolderDialog.SelectedPath;
                        break;
                }
            }
        }
        
    }
}
