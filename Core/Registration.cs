using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataBase;
using System.Collections.ObjectModel;

namespace Core
{
	public class Registration
	{
		public static ObservableCollection<User> users { get; set; }
		public static void RegistrationUser(string login, string password)
		{
			User newUser = new User();
			newUser.Login = login;
			newUser.Password = password;

			BdConnection.connection.User.Add(newUser);
			BdConnection.connection.SaveChanges();
		}
		public static bool UniqueLogin(string login)
		{
			users = new ObservableCollection<User>(BdConnection.connection.User.ToList());
			bool loginUnic = true;
			foreach (var i in users)
			{
				if (i.Login == login)
				{
					loginUnic = false;
				}
			}
			return loginUnic;
		}
	}
}
