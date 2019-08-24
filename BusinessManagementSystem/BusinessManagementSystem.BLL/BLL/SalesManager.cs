using BusinessManagementSystem.Models.Models;
using BusinessManagementSystem.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystem.BLL.BLL
{
    public class SalesManager
    {

        SalesRepository _salesRepository = new SalesRepository();
        public bool Save(SalesDetails salesModel)
        {
            return _salesRepository.Save(salesModel);
        }
        public bool SaveSalesProduct(Sale sale)
        {
            return _salesRepository.SaveSalesProduct(sale);

        }
        public int GetProductAvailableQuantity(Product product)
        {
            return _salesRepository.GetProductAvailableQuantity(product);
        }
        public bool Update(SalesDetails salesModel)
        {
            return _salesRepository.Update(salesModel);
        }

        public bool Delete(Sale sale)
        {
            return _salesRepository.Delete(sale);
        }
        public SalesDetails FindById(SalesDetails salesModel)
        {
            return _salesRepository.FindById(salesModel);
        }
        public List<Sale> FindAll()
        {
            return _salesRepository.FindAll();
        }

        public bool Save(List<SalesDetails> salesModel)
        {
            return _salesRepository.Save(salesModel);
        }
        public Customer GetLoyalty_Point(int CustId)
        {
            return _salesRepository.GetLoyalty_Point(CustId);
        }
        public Product ProductDetails(int ProId)
        {
            return _salesRepository.ProductDetails(ProId);
        }
        public List<SalesDetails> VoucherDetails(int voucherNo)
        {
            return _salesRepository.VoucherDetails(voucherNo);
        }
            public Customer GetCustLoyaltyPoints(int CustId)
        {
            return _salesRepository.GetCustLoyaltyPoints(CustId);
        }
    }
}
