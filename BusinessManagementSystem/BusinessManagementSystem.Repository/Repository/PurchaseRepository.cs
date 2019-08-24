using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessManagementSystem.Models.Models;
using BusinessManagementSystem.DatabaseContext.DatabaseContext;

namespace BusinessManagementSystem.Repository.Repository
{
    public class PurchaseRepository
    {
        BusinessDbContext db = new BusinessDbContext();
        public bool InsertPurchaseProduct(Purchase purchase)
        {
            db.Purchases.Add(purchase);
            return db.SaveChanges() > 0;
        }
        public ProductViewModel LatestProduct(Product product)
        {
            ProductViewModel aProduct = new ProductViewModel();
            var products = db.PurchaseDetails.Where(c => c.ProductId == product.ID).ToList();
            if (products.Count > 0)
            {
                int count = 0;
                int latestList = products.Count;
                foreach (var pro in products)
                {
                    count++;
                    if (latestList == count)
                    {
                        aProduct.ProductId = pro.ProductId;
                        aProduct.PreviousCostPrice = pro.UnitPrice;
                        aProduct.PreviousMRP = pro.NewMRP;
                    }
                }
            }
            return aProduct;
        }
        public List<PurchaseDetails> GetPurchaseProducts()
        {
            var purchases = db.PurchaseDetails.Include(c => c.Product).ToList();
            return purchases;
        }
        public Product GetProductById(Product product)
        {
            return db.Products.Where(c => c.ID == product.ID).FirstOrDefault();
        }
        public List<Supplier> GetSuppliers()
        {
            return db.Suppliers.ToList();
        }
        public List<Product> GetProducts()
        {
            return db.Products.Include(c => c.Category).ToList();
        }
    }
}
