using AutoMapper;
using BusinessManagementSystem.BLL.BLL;
using BusinessManagementSystem.Models;
using BusinessManagementSystem.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessManagementSystem.Controllers
{
    public class SalesController : Controller
    {
        SalesManager _salesManager = new SalesManager();
        private SalesDetails _salesDetails = new SalesDetails();
        private Sale sale = new Sale();
        CustomerManager _customerManager = new CustomerManager();
        ProductManager _productManager = new ProductManager();
        // GET: Sales
        [HttpGet]
        public ActionResult Save()
        {
            SalesSaveViewModel salesModelVm = new SalesSaveViewModel();
            salesModelVm.CustomerList = _customerManager.FindAll().Select(c => new SelectListItem()
            {
                Value = c.ID.ToString(),
                Text = c.Name
            });
            return View(salesModelVm);
        }
        [HttpPost]
        public ActionResult Save(SalesSaveViewModel salesModelVm)
        {
            if (ModelState.IsValid)
            {
                SalesDetails salesModel = new SalesDetails();
                //salesModel = Mapper.Map<SalesDetails>(salesModelVm);

                if (_salesManager.Save(salesModel))
                {
                    ViewBag.SuccessMsg = "Data Saved SuccessFully!";
                }
                else
                {
                    ViewBag.FailMsg = "Data Saved Fail!";
                }
            }
            else
            {
                ViewBag.FailMsg = "Data Validtion Fail!";
            }
            salesModelVm.CustomerList = _customerManager.FindAll().Select(c => new SelectListItem()
            {
                Value = c.ID.ToString(),
                Text = c.Name
            });
            return View(salesModelVm);
        }
        public ActionResult Delete(Sale sale)
        {
            sale.Id = sale.Id;

            if (_salesManager.Delete(sale))
            {
                ViewBag.SuccessMsg = "Data Delete SuccessFully!";
                TempData["SuccessMessage"] = "Data Delete SuccessFully!";
                return RedirectToAction("FindAll");
            }
            else
            {
                ViewBag.FailMsg = "Data Delete Fail!";
                TempData["SuccessMessage"] = "Data Delete Fail!";
                return RedirectToAction("FindAll");
            }

            
        }
        [HttpGet]
        public ActionResult FindAll(SalesSaveViewModel salesSaveViewModel)
        {
            SalesSaveViewModel salesSaveVM = new SalesSaveViewModel();

            salesSaveVM.SalesList = _salesManager.FindAll();

            salesSaveVM.CustomerList = _customerManager.FindAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.ID.ToString(),
                    Text = c.Name
                });
            return View(salesSaveVM);
        }
        [HttpPost]
        public ActionResult FindAll(Customer Customer)
        {
            SalesSaveViewModel salesSaveVM = new SalesSaveViewModel();
            var customers = _customerManager.FindAll();
            if (Customer.Name != null)
            {
                customers = customers.Where(c => c.Name.ToLower().Contains(Customer.Name.ToLower())).ToList();
            }

            foreach (var v in customers)
            {
                Customer.ID = v.ID;
            }
            var salesList = _salesManager.FindAll();

            if (Customer.ID != 0)
            {
                salesList = salesList.Where(c => c.CustomerId == Customer.ID).ToList();
            }

            salesSaveVM.SalesList = salesList;

            salesSaveVM.CustomerList = _customerManager.FindAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.ID.ToString(),
                    Text = c.Name
                });
            return View(salesSaveVM);
        }

        public ActionResult SalesAdd()
        {
            var customers = _customerManager.FindAll();
            ViewBag.Customers = new SelectList(customers, "Id", "Name");

            var products = _productManager.GetAllProducts();
            ViewBag.Products = new SelectList(products, "ID", "Name");

            return View();
        }

        [HttpPost]
        public ActionResult SalesAdd(SalesSaveViewModel Model)
        {
            sale.CustomerId = Model.CustomerId;
            int loyaltyPoint = (Convert.ToInt32(Model.CustomerPayment) / 1000);
            Customer customer = new Customer();
            customer.ID = sale.CustomerId;
            var aCustomer = _customerManager.FindById(customer);
            if (Model.Discount > 0)
            {
                aCustomer.Loyalty_Point = aCustomer.Loyalty_Point - (Convert.ToInt32(Model.Discount * 10));
            }
            else
            {
                aCustomer.Loyalty_Point = aCustomer.Loyalty_Point + loyaltyPoint;
            }


            sale.Date = Model.Date;
          
            sale.CustomerPayment = Model.CustomerPayment;
            sale.SalesDetailsList = Model.SalesDetailsList;
            if (_salesManager.SaveSalesProduct(sale))
            {
                if (_customerManager.UpdateCustomer(aCustomer))

                {
                    var customersList = _customerManager.FindAll();
                    ViewBag.Customers = new SelectList(customersList, "Id", "Name");

                    var products = _productManager.GetAllProducts();
                    ViewBag.Products = new SelectList(products, "ID", "Name");
                    ViewBag.SuccessMsg = "Data Saved SuccessFully!";
                    return View();
                }

            }
            else
            {
                ViewBag.FailMsg = "Data Saved Fail!";
            }



            return View(Model);
        }
        public JsonResult GetLoyalty_Point(int CustId)
        {
            var customer = _salesManager.GetLoyalty_Point(CustId);

            return Json(customer, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ProductDetails(int ProId)
        {
            var Product = _salesManager.ProductDetails(ProId);

            return Json(Product, JsonRequestBehavior.AllowGet);
        }
        public ActionResult VoucherDetails(int voucherNo)
        {

            var vouchweDetails = _salesManager.VoucherDetails(voucherNo);
            SalesSaveViewModel salesSaveView = new SalesSaveViewModel();
            foreach (var p in vouchweDetails)
            {
                SalesDetails s = new SalesDetails();
                s.Quantity = p.Quantity;
                s.UnitPrice = p.UnitPrice;
                s.ProductsId = p.ProductsId;
                s.SubTotal = p.SubTotal;
                salesSaveView.SalesDetailsList.Add(s);
            }
            return PartialView("Shared/_SalesDetails", salesSaveView);
        }
        public JsonResult GetCustLoyaltyPoints(int CustId)
        {
            var customer = _salesManager.GetCustLoyaltyPoints(CustId);

            return Json(customer, JsonRequestBehavior.AllowGet);
        }
      

    }
}