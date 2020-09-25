using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Web_Store.Models;

namespace Web_Store.Entities
{
	public class Category
	{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }
        public string UserId { get; set; }
        public DateTime DateAdded { get; set; }

        public ApplicationUser User { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}