namespace BusinessManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SalesDetail
    {
        public int Id { get; set; }

        public int SaleId { get; set; }

        public int ProductsId { get; set; }

        public int Quantity { get; set; }

        public float UnitPrice { get; set; }

        public float SubTotal { get; set; }

        public virtual Product Product { get; set; }

        //public virtual Sale Sale { get; set; }
    }
}
