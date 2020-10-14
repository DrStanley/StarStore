using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Web_Store.Entities;
using Web_Store.Interfaces;
using Web_Store.Models;

namespace Web_Store.Services
{
	public class CategoryServices : ICategory
	{
		public ApplicationDbContext dbContext;
		public CategoryServices(ApplicationDbContext db)
		{
			dbContext = db;
		}
		public string AddCategory(AddCategoryViewModel addCategory, string userId)
		{
			Category newcategory = new Category()
			{
				CategoryName = addCategory.CategoryName,
				Description = addCategory.Description,
				UserId = userId,
				DateAdded = DateTime.Now
			};

			if (!dbContext.categories.Any(o => o.CategoryName == addCategory.CategoryName))
			{
				// no Match!
				dbContext.categories.Add(newcategory);
				dbContext.SaveChanges();
				return "Saved";
			}
			else
			{
				return "Category already Exist";
			}
		}

		public List<string> GetCategory()
		{
			List<string> all = new List<string>();
			all.Add("All");

			all.AddRange(dbContext.categories.Select(o => o.CategoryName).ToList());

			return all;
		}

		public int GetCategoryID(string category)
		{
			int all = dbContext.categories
						.Where(o => o.CategoryName == category)
						.Select(o => o.CategoryID)
						.SingleOrDefault();

			return all;
		}
	}
}