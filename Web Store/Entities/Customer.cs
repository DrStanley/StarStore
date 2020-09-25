using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Web_Store.Models;

namespace Web_Store.Entities
{
	public class Customer
	{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DateCreated { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

    }
}