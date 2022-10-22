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
using Core;
using Core.DataBase;
using System.IO;

namespace NailsPractik.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddShopPage.xaml
    /// </summary>
    public partial class AddShopPage : Page
    { 
        public static Shop shop = new Shop();
        public AddShopPage()
        {
            InitializeComponent();
            
        }

        private void btnAddImg_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFile = new Microsoft.Win32.OpenFileDialog()
            {
                Filter ="*.jpg|*.jpg|*.png|*.png"
            };
            if (openFile.ShowDialog().GetValueOrDefault())
            {
                shop.Image = File.ReadAllBytes(openFile.FileName);
                ImgPhoto.Source = new BitmapImage(new Uri(openFile.FileName));
            }

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnSaveShop_Click(object sender, RoutedEventArgs e)
        {
            shop.Title = tbTitle.Text.Trim();
            shop.Link = tbLink.Text.Trim();
            BdConnection.connection.Shop.Add(shop);
            BdConnection.connection.SaveChanges();

        }
    }
}
