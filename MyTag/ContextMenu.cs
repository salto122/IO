using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.IO;
using System.Diagnostics;


namespace MyTag
{
    public partial class MainWindow
    {

        private void CM_BT_OpenLocation(object sender, RoutedEventArgs e)
        {
            string filePath = ((ImageTest)SelectedItemT.SelectedItem).ImagePath;
            string folderPath = Directory.GetParent(filePath).ToString();

            if (Directory.Exists(folderPath))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = "/select, " + filePath,
                    FileName = "explorer.exe"
                };

                Process.Start(startInfo);
            }
            else
            {
                MessageBox.Show(string.Format("{0} Directory does not exist!", folderPath));
            }
        }


        private void CM_BT_Open(object sender, RoutedEventArgs e)
        {
            
            string filePath = ((ImageTest)SelectedItemT.SelectedItem).ImagePath;
            if (File.Exists(filePath))
                Process.Start("explorer.exe", filePath);
            else
            {
                MessageBox.Show(string.Format("{0} File does not exist!", filePath));
            }
        }
        private void CM_BT_ModifyTags(object sender, RoutedEventArgs e)
        {

        }
        private void CM_BT_Rotate(object sender, RoutedEventArgs e)
        {

        }
        private void CM_BT_Rename(object sender, RoutedEventArgs e)
        {

        }
        private void CM_BT_CopyPath(object sender, RoutedEventArgs e)
        {

        }
        private void CM_BT_SaveOnDesktop(object sender, RoutedEventArgs e)
        {

        }
        private void CM_BT_Delete(object sender, RoutedEventArgs e)
        {

        }
    }
}
