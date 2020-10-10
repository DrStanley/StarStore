using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Store.Entities;
using Web_Store.Models;

namespace Web_Store.Interfaces
{
	public interface IProduct
	{
		List<Product> GetProducts(string category);
		string AddNewProduct(AddProductViewModel addProduct, string userid);
	}
}
