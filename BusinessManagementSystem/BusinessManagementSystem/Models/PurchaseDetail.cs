namespace BusinessManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PurchaseDetail
    {
        public int Id { get; set; }

        public DateTime ManufactureDate { get; set; }

        public DateTime ExpireDate { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal NewMRP { get; set; }

        public string Remark { get; set; }

        public int PurchaseId { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public virtual Purchase Purchase { get; set; }
    }
}
