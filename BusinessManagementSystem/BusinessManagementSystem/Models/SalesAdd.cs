using BusinessManagementSystem.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessManagementSystem.Models
{
    public class SalesAdd
    {
        [Display(Name = "Customer")]
        [Required(ErrorMessage = "Please Select Customer!")]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Please Enter Date!")]
        public DateTime Date { get; set; }
        public List<SelectListItem> CustomerList { get; set; }
        public List<Sale> SalesList { get; set; }
        public List<SalesDetails> SalesDetailsList { get; set; }
        public List<SalesSaveViewModel> SalesHistory { get; set; }
    }
}