using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Store.Entities;
using Web_Store.Services;

namespace Web_Store.Interfaces
{
	public interface IShopTupleData
	{
		Tuple<List<ImagProduct>, List<string>, int> DisplayProduct(string userid, string category = null);
		Tuple<List<Product>, List<Cart>> DisplayCarts(string userid);
	}

}
