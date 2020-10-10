using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Store.Models;

namespace Web_Store.Interfaces
{
	public interface ICategory
	{
		  string AddCategory(AddCategoryViewModel addCategory, string userId);
		  List<string> GetCategory();
		int GetCategoryID(string category);
	}
}
