using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessManagementSystem.Models.Models;

namespace BusinessManagementSystem.DatabaseContext.DatabaseContext
{
    public class BusinessDbContext:DbContext
    {
        public DbSet <Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseDetails> PurchaseDetails { get; set; }
        
        public DbSet<Sale> Sales { set; get; }
        public DbSet<SalesDetails> SalesDetails { set; get; }
    }
}
