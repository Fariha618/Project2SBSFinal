using BusinessManagementSystem.Models.Models;
using BusinessManagementSystem.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagementSystem.BLL.BLL
{
    public class ReportingManager
    {
        ReportingRepository _reportingRepository = new ReportingRepository();
        public List<SalesDetails> PeriodictIncomeReport(ProductViewModel productViewModel)
        {
            return _reportingRepository.PeriodictIncomeReport(productViewModel);
        }
        public List<PurchaseDetails> PeriodictIncomeReportOnPurchase(ProductViewModel productViewModel)
        {
            return _reportingRepository.PeriodictIncomeReportOnPurchase(productViewModel);
        }
    }
}
