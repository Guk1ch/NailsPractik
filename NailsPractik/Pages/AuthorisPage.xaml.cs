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
using NailsPractik.Pages;

namespace NailsPractik.Pages
{
	/// <summary>
	/// Interaction logic for AuthorisPage.xaml
	/// </summary>
	public partial class AuthorisPage : Page
	{
		public static User user;
        public static int passCount = 0;
        public AuthorisPage()
		{
			InitializeComponent();
			tbLogin.Text = Properties.Settings.Default.Login;
		}

		private void btnLogin_Click(object sender, RoutedEventArgs e)
		{
            if (Properties.Settings.Default.Password < DateTime.Now)
            {
                string login = tbLogin.Text.Trim();
                string password = tbPass.Password.Trim();
                user = Core.Authorisation.AuthorisationUser(login, password);
                if (user != null)
                {
                    if (cbSaveLogin.IsChecked.GetValueOrDefault())
                    {
                        Properties.Settings.Default.Login = tbLogin.Text.Trim();
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        Properties.Settings.Default.Login = null;
                        Properties.Settings.Default.Save();
                    }

                    NavigationService.Navigate(new MainPage(user));
                }
                else
                {
                    passCount++;
                    MessageBox.Show("Неверный логин или пароль", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                    if (passCount == 3)
                    {
                        passCount = 0;
                        Properties.Settings.Default.Password = DateTime.Now.AddMinutes(1);
                        Properties.Settings.Default.Save();
                    }
                }
            }
            else
            {
                MessageBox.Show("Вы ввели неверный пароль 3 раза, возможность входа заблокирована на: \n" + (Properties.Settings.Default.Password - DateTime.Now).Seconds + " сек.");
            }
        }

		private void btnReg_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new RegistrationPage());
		}
	}
}
