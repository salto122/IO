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

            var images = GetImages();
            if (images.Count > 0)
                ListViewImages.ItemsSource = images;

            
        }

        private List<ImageTest> GetImages()
        {
            return new List<ImageTest>()
      {
        new ImageTest("#TAG1", "C:/REPOZYTORIA/IO prj/MyTag/Assets/test.jpg"),
        new ImageTest("#TAG2", "C:/REPOZYTORIA/IO prj/MyTag/Assets/test.jpg")

        

      };
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
        private void BT_Image_Click(object sender, RoutedEventArgs e)
        {

        }
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