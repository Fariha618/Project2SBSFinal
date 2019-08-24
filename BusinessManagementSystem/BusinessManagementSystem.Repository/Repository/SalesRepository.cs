using BusinessManagementSystem.DatabaseContext.DatabaseContext;
using BusinessManagementSystem.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystem.Repository.Repository
{
    public class SalesRepository
    {
        BusinessDbContext db = new BusinessDbContext();
        public bool Save(SalesDetails salesModel)
        {
            int isExecuted = 0;
            db.SalesDetails.Add(salesModel);
            isExecuted = db.SaveChanges();
            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }
        public bool SaveSalesProduct(Sale sale)
        {
            db.Sales.Add(sale);
            return db.SaveChanges() > 0;

        }

        public bool Save(List<SalesDetails> salesAdd)
        {
            int isExecuted = 0;

            db.SalesDetails.AddRange(salesAdd);
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }
        public SalesDetails FindById(SalesDetails salesModel)
        {
            SalesDetails aSales = db.SalesDetails.FirstOrDefault(c => c.Id == salesModel.Id);
            return aSales;
        }
        public bool Update(SalesDetails salesModel)
        {
            int isExecuted = 0;

            db.Entry(salesModel).State = EntityState.Modified;
            isExecuted = db.SaveChanges();
            if (isExecuted > 0)
            {
                return true;
            }
            return false;
        }
        public bool Delete(Sale sale)
        {
            int isExecuted = 0;
            Sale aSales = db.Sales.FirstOrDefault(c => c.Id == sale.Id);

            db.Sales.Remove(aSales);
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }
            return false;
        }
        public List<Sale> FindAll()
        {
            return db.Sales.Include(c => c.Customers).ToList();
        }
        public Customer GetLoyalty_Point(int CustId)
        {
            Customer aCustomer = db.Customers.FirstOrDefault(c => c.ID == CustId);
            return aCustomer;
        }
        public Product ProductDetails(int ProId)
        {
            Product aProduct = db.Products.FirstOrDefault(c => c.ID == ProId);
            return aProduct;
        }
        public List<SalesDetails> VoucherDetails(int voucherNo)
        {

            var salesDetialsList = db.SalesDetails.Include(c => c.Products).ToList();

            salesDetialsList = salesDetialsList.Where(c => c.SaleId == voucherNo).ToList();

            return salesDetialsList;
        }

        public Customer GetCustLoyaltyPoints(int CustId)
        {
            Customer aCustomer = db.Customers.FirstOrDefault(c => c.ID == CustId);
            return aCustomer;
        }
        public int GetProductAvailableQuantity(Product product)
        {
            int availableQuantity = 0;
            int purchaseQuantity = 0;
            int salesQuantity = 0;
            var purchaseProducts = db.PurchaseDetails.Where(c => c.ProductId == product.ID).ToList();
            foreach (var purchaseProduct in purchaseProducts)
            {
                purchaseQuantity += purchaseProduct.Quantity;
            }
            var salesProducts = db.SalesDetails.Where(c => c.ProductsId == product.ID).ToList();
            foreach (var salesProduct in salesProducts)
            {
                salesQuantity += salesProduct.Quantity;
            }
            availableQuantity = purchaseQuantity - salesQuantity;
            return availableQuantity;
        }
    }
}
