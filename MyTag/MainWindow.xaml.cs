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

namespace MyTag
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            LoadLogo();

            ImageTestLoad();

        }

        private void LoadLogo()
        {
            string LogoPath = System.IO.Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName) + @"\Assets\logo.jpg";
            Image_Logo.Source = new BitmapImage(new Uri(LogoPath));

        }

        public void ImageTestLoad()
        {
            var selItem = ListViewImages.SelectedItem;

            if (selItem != null)
            {
                var TEST = (ImageTest)selItem;
                TB_TagList.Text = TEST.Tag.ToString();
            }

            var Images = new List<ImageTest>();
            string TestImagePath = System.IO.Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName) + @"\Assets\test.jpg";
            for (int i = 0; i < 10; i++)
            {
                ListViewImages.Items.Add(new ImageTest($"#TAG{i}", TestImagePath));
            }

        }

        private void LB_SelImgae(object sender, SelectionChangedEventArgs e)
        {

            var item = (ListBox)sender;
            if (ListViewImages.SelectedItem != null)
                TB_TagList.Text = ((ImageTest)item.SelectedItem).Tag;
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

        public partial class ImageTest
        {
            public string Tag { get; set; }
            public string ImagePath { get; set; }
            public BitmapImage Image { get; set; }

            public ImageTest(string tag, string imagePath)
            {
                Tag = tag;
                ImagePath = imagePath;
                Image = new BitmapImage(new Uri(imagePath, UriKind.Relative));

            }



        }


    }
}