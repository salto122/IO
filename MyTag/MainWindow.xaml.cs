using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
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
using MyTag.ExtraWIndows;
using MyTag.Properties;
using Backend;


namespace MyTag
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        private static ListBox SelectedItemT;
        public static string ImportedImageTags;

        public MainWindow()
        {
            InitializeComponent();

            LoadLogo();

            ImageLoadToFront();
            
        }

        private void LoadLogo()
        {
            string LogoPath = System.IO.Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName) + @"\Assets\logo.jpg";
            Image_Logo.Source = new BitmapImage(new Uri(LogoPath));
        }

        public void ImageLoadToFront()
        {
            var selItem = ListViewImages.SelectedItem;

            if (selItem != null)
            {
                var TEST = (FrontendImage)selItem;
                TB_TagList.Text = TEST.Tag.ToString();
            }

            Picture picture = new Picture();

            string imageStorePath = Settings.Default.StorePath.ToString();
            string[] imageNamesJPG = Directory.GetFiles(imageStorePath, "*.jpg");
            string[] imageNamesPNG = Directory.GetFiles(imageStorePath, "*.png");

            string[] imageNames = imageNamesJPG.Concat(imageNamesPNG).ToArray();
            string[] tempNames = imageNamesJPG.Concat(imageNamesPNG).ToArray();
            imageNamesJPG.Concat(imageNamesPNG);
            for (int i = 0; i < imageNames.Length; i++)
            {
                tempNames[i] = System.IO.Path.GetFileName(imageNames[i]);
                tempNames[i] = tempNames[i].Substring(0, tempNames[i].Length - 4);

                if (picture.GetTag(tempNames[i]) != null)
                {
                    ListViewImages.Items.Add(new FrontendImage($"{picture.GetTag(tempNames[i])}", imageNames[i], "IDCS_" + DateTime.Now.ToString()));
                }
            }
        }

        private void LB_SelImgae(object sender, SelectionChangedEventArgs e)
        {

            var item = (ListBox)sender;
            if (ListViewImages.SelectedItem != null)
            {
                SelectedItemT = item;
                TB_TagList.Text = ((FrontendImage)item.SelectedItem).Tag;
                LB_Resolution.Content = "Resolution: " + ((FrontendImage)item.SelectedItem).ResX.ToString() + " x " + ((FrontendImage)item.SelectedItem).ResY.ToString();
                LB_ImageName.Content = ((FrontendImage)item.SelectedItem).IDCS.ToString();
                LB_CreateDate.Content = "Create Date: " + GetCreateDate((FrontendImage)item.SelectedItem);
                LB_ImageSize.Content = "Size: " + GetFileSize((FrontendImage)item.SelectedItem) + " KB";
                LB_AddDate.Content = "Added date: ";
            }
            if (ListViewImages.SelectedItem == null)
                TB_TagList.Text = string.Empty;
        }

        private void ListViewImages_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            if (ListViewImages.SelectedItem == null)
                e.Handled = true;
        }

        private void ListViewImages_MouseDown(object sender, MouseButtonEventArgs e)
        {

            HitTestResult r = VisualTreeHelper.HitTest(this, e.GetPosition(this));
            if (r.VisualHit.GetType() != typeof(ListBoxItem))
            {
                ListViewImages.UnselectAll();
                ListViewImages.SelectedItem = null;
            }
        }
        private void BT_ShowMyTags_CLick(object sender, RoutedEventArgs e)
        {

        }

        private void BT_AddNewTag_CLick(object sender, RoutedEventArgs e)
        {

        }

        private void BT_DeleteTag_CLick(object sender, RoutedEventArgs e)
        {

        }

        private void BT_ModifyTag_CLick(object sender, RoutedEventArgs e)
        {

        }

        private void BT_FavouriteTags_CLick(object sender, RoutedEventArgs e)
        {

        }

        private void BT_RecentImages_CLick(object sender, RoutedEventArgs e)
        {

        }

        private void BT_ImportImages_CLick(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Filter = "(*.jpg, *.png)|*.jpg;*.png";
            string selectedImagePath;
            string fileName;

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                selectedImagePath = openFileDialog.FileName;
                fileName = System.IO.Path.GetFileName(selectedImagePath);

                Picture picture = new Picture();

                AddTagWindow MyAddTagWindow = new AddTagWindow();
                MyAddTagWindow.ShowDialog();

                if (!File.Exists(Settings.Default.StorePath))
                {
                    if (AddTagWindow.AddTagStatusCaneled == false)
                    {
                        try
                        {
                            //fileName = picture.SetName(fileName) + ".jpg"; // .jpg placeholder - to fix
                            fileName = picture.SetNameAndTags(fileName, MainWindow.ImportedImageTags) + ".jpg";

                            File.Copy(selectedImagePath, Settings.Default.StorePath + @"\" + fileName);
                        }

                        catch (Exception)
                        {
                            MessageBox.Show(string.Format("{0} file already exist!", fileName));
                        }
                    }
                    else
                    {
                        AddTagWindow.AddTagStatusCaneled = false;
                    }
                }
            }
            ReloadImagesInListBox();
            Debug.WriteLine("AddTagStatusCaneled: " + AddTagWindow.AddTagStatusCaneled);
        }

        private void BT_Settings_CLick(object sender, RoutedEventArgs e)
        {
            SettingsWindow MySettingWindow = new SettingsWindow();
            MySettingWindow.ShowDialog();
        }

        private void BT_Search_Click(object sender, RoutedEventArgs e)
        {

        }
        private void TB_PressEnter(object sender, RoutedEventArgs e)
        {

        }

        public partial class FrontendImage
        {
            public string Tag { get; set; }
            public string ImagePath { get; set; }
            public BitmapImage Image { get; set; }
            public int ResX { get; set; }
            public int ResY { get; set; }
            public DateTime DateAdd { get; set; }

            public string IDCS { get; set; }

            public FrontendImage(string tag, string imagePath, string idcs)
            {
                Tag = tag;
                ImagePath = imagePath;
                Image = new BitmapImage(new Uri(imagePath, UriKind.Relative));
                ResX = Image.PixelWidth;
                ResY = Image.PixelHeight;
                IDCS = idcs;
            }
        }
        public DateTime GetCreateDate(FrontendImage image)
        {
            DateTime CreateDate = File.GetCreationTime(image.ImagePath);
            return CreateDate;
        }

        public string GetFileSize(FrontendImage image)
        {
            double size = Math.Round(new FileInfo(image.ImagePath).Length / 1024.0, 2);
            return size.ToString();
        }

        private void ReloadImagesInListBox()
        {
            ListViewImages.Items.Clear();
            ImageLoadToFront();
        }

    }
}
