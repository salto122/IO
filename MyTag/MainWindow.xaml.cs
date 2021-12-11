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

namespace MyTag
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string DisplayedLogo
        {
            get { return @"C:/REPOZYTORIA/IO prj/MyTag/Assets/logo.jpg"; }
        }
        public MainWindow()
        {
            InitializeComponent();

            var Images = new List<ImageTest>()
                                              {
                                                new ImageTest("#TAG1", "C:/REPOZYTORIA/IO prj/MyTag/Assets/test.jpg"),
                                                new ImageTest("#TAG2", "C:/REPOZYTORIA/IO prj/MyTag/Assets/test.jpg"),
                                                new ImageTest("#TAG3", "C:/REPOZYTORIA/IO prj/MyTag/Assets/logo.jpg"),
                                                new ImageTest("#TAG4", "C:/REPOZYTORIA/IO prj/MyTag/Assets/logo.jpg"),
                                                new ImageTest("#TAG5", "C:/REPOZYTORIA/IO prj/MyTag/Assets/logo.jpg"),
                                                new ImageTest("#TAG6", "C:/REPOZYTORIA/IO prj/MyTag/Assets/logo.jpg"),
                                                new ImageTest("#TAG7", "C:/REPOZYTORIA/IO prj/MyTag/Assets/logo.jpg"),
                                                new ImageTest("#TAG8", "C:/REPOZYTORIA/IO prj/MyTag/Assets/logo.jpg"),
                                                new ImageTest("#TAG9", "C:/REPOZYTORIA/IO prj/MyTag/Assets/logo.jpg")
                                              };
            //if (images.Count > 0)
            //   ListViewImages.ItemsSource = images;
            for (int i = 0; i < Images.Count; i++)
            {
                ListViewImages.Items.Add(new ImageTest($"#TAG{i}", "C:/REPOZYTORIA/IO prj/MyTag/Assets/test.jpg"));
            }
            //foreach (var item in Images)
            //{
            //    ListViewImages.Items.Add(new ImageTest("#TAG123", "C:/REPOZYTORIA/IO prj/MyTag/Assets/test.jpg"));
            //}
            var selItem = ListViewImages.SelectedItem;

            if (selItem != null)
            {
                var TEST = (ImageTest)selItem;
                TB_TagList.Text = TEST.Tag.ToString();
            }

        }
        private void LB_SelImgae(object sender, SelectionChangedEventArgs e)
        {
            var item = (ListBox)sender;
           TB_TagList.Text= ((ImageTest)item.SelectedItem).Tag;
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

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}