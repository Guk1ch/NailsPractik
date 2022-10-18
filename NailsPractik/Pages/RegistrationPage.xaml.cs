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
	/// Interaction logic for RegistrationPage.xaml
	/// </summary>
	public partial class RegistrationPage : Page
	{
		public RegistrationPage()
		{
			InitializeComponent();
		}

		private void btnReg_Click(object sender, RoutedEventArgs e)
		{
			string login = tbLogin.Text.Trim();
			string pass = tbPass.Text.Trim();
			if (Registration.UniqueLogin(login))
			{
				if ( login != "" && pass != "")
				{
					Registration.RegistrationUser( login, pass);

					System.Windows.MessageBox.Show("Аккаунт успешно создан!");
					NavigationService.Navigate(new AuthorisPage());
				}
				else
				{
					System.Windows.MessageBox.Show("Заполните все поля!");
				}
			}
			else
			{
				tbLogin.Text = "";
				System.Windows.MessageBox.Show("Придумайте другой логин");
			}
		}

		private void btnBack_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new AuthorisPage());
		}
	}
}
