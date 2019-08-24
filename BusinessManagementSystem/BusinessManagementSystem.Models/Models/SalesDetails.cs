using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystem.Models.Models
{
   public  class SalesDetails
    {
        public int Id { get; set; }
        public int SaleId { get; set; }
        public Sale Sales { get; set; }
        public int ProductsId { get; set; }
        public Product Products { get; set; }
        public int Quantity { get; set; }
        public float UnitPrice { get; set; }
        public float SubTotal { get; set; }
    }
}
