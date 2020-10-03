using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Store.Entities;

namespace Web_Store.Interfaces
{
	interface ICart
	{
		string AddCart(Product product, string userid);
		string RemoveCart(Cart cart);
		int GetCartCount(string userid);
		List<Product> GetCartProducts(List<Cart> carts);
	}
}
