using BusinessManagementSystem.Models.Models;
using BusinessManagementSystem.DatabaseContext.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BusinessManagementSystem.Repository.Repository
{
    public class ReportingRepository
    {
        BusinessDbContext db = new BusinessDbContext();
        public List<SalesDetails> PeriodictIncomeReport(ProductViewModel productViewModel)
        {
            List<SalesDetails> salesDetails = new List<SalesDetails>();
            var saleProducts = db.Sales.Where(c => c.Date >= productViewModel.StartDate && c.Date <= productViewModel.EndDate).ToList();
            foreach (var product in saleProducts)
            {
                var saleProductList = db.SalesDetails.Include(c => c.Products).Where(c => c.SaleId == product.Id).ToList();
                foreach(var saleProduct in saleProductList)
                {
                    salesDetails.Add(saleProduct);
                }
                
            }
            return salesDetails;
        }
        public List<PurchaseDetails> PeriodictIncomeReportOnPurchase(ProductViewModel productViewModel)
        {
            List<PurchaseDetails> purchaseDetails = new List<PurchaseDetails>();
            var purchaseProducts = db.Purchases.Where(c => c.Date >= productViewModel.StartDate && c.Date <= productViewModel.EndDate).ToList();
            foreach (var product in purchaseProducts)
            {
                var purchaseProductList = db.PurchaseDetails.Include(c => c.Product).Where(c => c.PurchaseId == product.Id).ToList();
                foreach(var purchaseProduct in purchaseProductList)
                {
                    purchaseDetails.Add(purchaseProduct);
                }
            }
            return purchaseDetails;
        }
    }
}
