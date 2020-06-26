using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjectSDA.Models
{
    public class Order
    {
        [Display(Name = "Order Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]

        [Display(Name = "Quantity")]
        public int quantity { get; set; }

        [Required(ErrorMessage = "Price is required.")]

        [Display(Name = "Total Price")]
        public int Price { get; set; }

      
    }
}