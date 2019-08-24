namespace BusinessManagementSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StockSearchModel : DbContext
    {
        public StockSearchModel()
            : base("name=StockSearchModel")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<PurchaseDetail> PurchaseDetails { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }        
        public virtual DbSet<SalesDetail> SalesDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasMany(e => e.SalesDetails)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.ProductsId);
        }
    }
}
