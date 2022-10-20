using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataBase;

namespace Core
{
	public class ShopFunction
	{
		public static List<Shop> GetShops() 
		{
			List<Shop> shops = BdConnection.connection.Shop.ToList();
			return shops;
		}
	}
}
