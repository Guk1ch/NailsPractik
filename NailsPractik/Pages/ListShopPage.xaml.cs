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

namespace NailsPractik.Pages
{
	/// <summary>
	/// Interaction logic for ListShopPage.xaml
	/// </summary>
	public partial class ListShopPage : Page
	{
		public static List<Shop> shopList { get; set; }
		public ListShopPage()
		{
			InitializeComponent();
			shopList = ShopFunction.GetShops();
			this.DataContext = this;
		}

		private void btnBack_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.GoBack();
		}


		private void lvShops_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}
	}
}
