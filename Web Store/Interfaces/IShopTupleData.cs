using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Store.Entities;

namespace Web_Store.Interfaces
{
	interface IShopTupleData
	{
		Tuple<List<Product>, List<string>, int> DisplayProduct(string userid, string category = null);
		Tuple<List<Product>, List<Cart>> DisplayCarts(string userid);
	}

}
