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
using Prism.Commands;

namespace NailsPractik.Pages
{
	/// <summary>
	/// Interaction logic for ListShopPage.xaml
	/// </summary>
	public partial class ListShopPage : Page
	{
		public Shop shop { get; set; }
		public static List<Shop> shopList { get; set; }
		private void NavHomeView(object Id)
		{
			if (Id is string destinationurl)
				System.Diagnostics.Process.Start(shop.Link);
		}
		public string ExternalURL { get => shop.Link; }
		private readonly ICommand navHomeViewCommand;
		public ICommand NavHomeViewCommand
		{
			get { return navHomeViewCommand; }
		}
		public ListShopPage()
		{
			InitializeComponent();
			navHomeViewCommand = new DelegateCommand<object>(NavHomeView);
			shopList = ShopFunction.GetShops();
			this.DataContext = this;
		}

		private void btnBack_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.GoBack();
		}


		private void lvShops_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if(lvShops.SelectedItem != null)
			{
				shop = lvShops.SelectedItem as Shop;
			}
		}

        private void btnAddNewShop_Click(object sender, RoutedEventArgs e)
        {
			NavigationService.Navigate(new AddShopPage());
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
			System.Diagnostics.Process.Start(e.Uri.ToString());
        }
    }
}
