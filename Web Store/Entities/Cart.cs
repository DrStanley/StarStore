using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Web_Store.Models;

namespace Web_Store.Entities
{
	public class Cart
	{
        [Key]

        public string CartId { get; set; }

        public int Quantity { get; set; }

        public DateTime DateCreated { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }


    }
}