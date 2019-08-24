using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessManagementSystem.Models
{
    public class StockVM
    {
        public Category Category { get; set; }
        public Product Product { get; set; }
        public Purchase Purchase { get; set; }
        public PurchaseDetail PurchaseDetail { get; set; }      
        public SalesDetail GetSalesDetail { get; set; }
    }
}