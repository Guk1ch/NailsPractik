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
	/// Interaction logic for MainPage.xaml
	/// </summary>
	public partial class MainPage : Page
	{
		public MainPage(User user)
		{
			InitializeComponent();
		}

		private void btnReg_Click(object sender, RoutedEventArgs e)
		{

		}

		private void btnLogin_Click(object sender, RoutedEventArgs e)
		{

		}

		private void btnSaveStatic_Click(object sender, RoutedEventArgs e)
		{

		}

		private void btnShop_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new ListShopPage());
		}

        private void btnAddNewClient_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
