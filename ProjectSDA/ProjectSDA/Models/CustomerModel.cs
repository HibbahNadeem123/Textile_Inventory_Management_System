using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjectSDA.Models
{
    public class CustomerModel
    {
        [Display(Name = "CustomerId")]
        public int CID { get; set; }

        [Required(ErrorMessage = "Customer Name is required.")]

        [Display(Name = "Customer Name")]
        public string CName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Company Name is required.")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        public string Country { get; set; }
    }
}