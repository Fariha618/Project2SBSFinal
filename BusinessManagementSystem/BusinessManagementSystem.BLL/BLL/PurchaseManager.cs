using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessManagementSystem.Models.Models;
using BusinessManagementSystem.Repository.Repository;
namespace BusinessManagementSystem.BLL.BLL
{
    public class PurchaseManager
    {
        PurchaseRepository _purchaseRepository = new PurchaseRepository();
        public bool InsertPurchaseProduct(Purchase purchase)
        {
            return _purchaseRepository.InsertPurchaseProduct(purchase);
        }
        public ProductViewModel LatestProduct(Product product)
        {
            return _purchaseRepository.LatestProduct(product);
        }
        public List<PurchaseDetails> GetPurchaseProducts()
        {
            return _purchaseRepository.GetPurchaseProducts();
        }

        public Product GetProductById(Product product)
        {
            return _purchaseRepository.GetProductById(product);
        }
        public List<Product> GetProducts()
        {
            return _purchaseRepository.GetProducts();
        }
        public List<Supplier> GetSuppliers()
        {
            return _purchaseRepository.GetSuppliers();
        }
    }
}
