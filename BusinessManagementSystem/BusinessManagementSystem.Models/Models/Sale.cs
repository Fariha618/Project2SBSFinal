using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystem.Models.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public Customer Customers { get; set; }
        public float CustomerPayment { get; set; }
        
        public List<SalesDetails> SalesDetailsList { get; set; }
    }
}
