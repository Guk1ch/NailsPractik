using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Core.DataBase;

namespace Core
{
	public class Authorisation
	{
		public static ObservableCollection<User> users { get; set; }
		public static User AuthorisationUser(string login, string password) 
		{
			users = new ObservableCollection<User>(BdConnection.connection.User.ToList());
			var userExists = users.Where(user => user.Login == login && user.Password == password).FirstOrDefault();
			return userExists;
		}
	}
}
