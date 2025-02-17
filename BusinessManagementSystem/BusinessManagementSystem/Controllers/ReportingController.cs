﻿using BusinessManagementSystem.BLL.BLL;
using BusinessManagementSystem.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessManagementSystem.Controllers
{
    public class ReportingController : Controller
    {
        ProductManager _productManager = new ProductManager();
        ReportingManager _reportingManager = new ReportingManager();
        PurchaseManager _purchseManager = new PurchaseManager();
        SalesManager _salesManager = new SalesManager();
        Product _product = new Product();

        public ActionResult PeriodictIncomeReport()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PeriodictIncomeReport(ProductViewModel productViewModel)
        {
            List<ProductViewModel> productViewModels = new List<ProductViewModel>();
            List<ProductViewModel> productsLatestRecord = new List<ProductViewModel>();
            var products = _productManager.GetAllProducts();
            foreach (var product in products)
            {
                var aProduct = _purchseManager.LatestProduct(product);
                productsLatestRecord.Add(aProduct);
            }
            var salesProducts = _reportingManager.PeriodictIncomeReport(productViewModel);
            foreach (var saleProduct in salesProducts)
            {
                ProductViewModel model = new ProductViewModel();
                var product = productsLatestRecord.Where(c => c.ProductId == saleProduct.ProductsId).FirstOrDefault();
                _product.ID = product.ProductId;
                var aProduct = _productManager.GetProductByID(_product);
                model.ProductCode = aProduct.Code;
                model.ProductName = aProduct.Name;
                model.CategoryName = aProduct.Category.Name;
                model.TotalCostPrice = product.PreviousCostPrice * saleProduct.Quantity;
                model.SalesPrice = product.PreviousMRP * saleProduct.Quantity;
                model.Profit = model.SalesPrice - model.TotalCostPrice;
                productViewModels.Add(model);
            }
            foreach (var model in productViewModels)
            {
                ProductViewModel aModel = new ProductViewModel();
                if (productViewModel.Products.Count > 0)
                {
                    int count = 0;
                    int countValue = productViewModel.Products.Count;
                    foreach (var p in productViewModel.Products)
                    {
                        count++;
                        if (p.ProductName == model.ProductName)
                        {
                            p.TotalCostPrice += model.TotalCostPrice;
                            p.SalesPrice += model.SalesPrice;
                            p.Profit += model.Profit;
                            break;
                        }
                        else
                        {
                            if (count == countValue)
                            {
                                aModel.ProductCode = model.ProductCode;
                                aModel.ProductName = model.ProductName;
                                aModel.CategoryName = model.CategoryName;
                                aModel.TotalCostPrice = model.TotalCostPrice;
                                aModel.SalesPrice = model.SalesPrice;
                                aModel.Profit = model.Profit;
                                productViewModel.Products.Add(aModel);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    aModel.ProductCode = model.ProductCode;
                    aModel.ProductName = model.ProductName;
                    aModel.CategoryName = model.CategoryName;
                    aModel.TotalCostPrice = model.TotalCostPrice;
                    aModel.SalesPrice = model.SalesPrice;
                    aModel.Profit = model.Profit;
                    productViewModel.Products.Add(aModel);
                }

            }
            return View(productViewModel);
        }
        public ActionResult PeriodicIncomeExpenseOnPurchase()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PeriodicIncomeExpenseOnPurchase(ProductViewModel productViewModel)
        {
            List<ProductViewModel> productViewModels = new List<ProductViewModel>();
            List<ProductViewModel> productsLatestRecord = new List<ProductViewModel>();
            var products = _productManager.GetAllProducts();
            foreach (var product in products)
            {
                var aProduct = _purchseManager.LatestProduct(product);
                productsLatestRecord.Add(aProduct);
            }
            var purchaseProducts = _reportingManager.PeriodictIncomeReportOnPurchase(productViewModel);
            foreach (var purchaseProduct in purchaseProducts)
            {
                ProductViewModel model = new ProductViewModel();
                var product = productsLatestRecord.Where(c => c.ProductId == purchaseProduct.ProductId).FirstOrDefault();
                _product.ID = product.ProductId;
                int availableQuantity = _salesManager.GetProductAvailableQuantity(_product);
                var aProduct = _productManager.GetProductByID(_product);
                model.ProductCode = aProduct.Code;
                model.ProductName = aProduct.Name;
                model.CategoryName = aProduct.Category.Name;
                model.TotalCostPrice = product.PreviousCostPrice * availableQuantity;
                model.SalesPrice = product.PreviousMRP * availableQuantity;
                model.Profit = model.SalesPrice - model.TotalCostPrice;
                productViewModels.Add(model);
            }
            foreach (var model in productViewModels)
            {
                ProductViewModel aModel = new ProductViewModel();
                if (productViewModel.Products.Count > 0)
                {
                    int count = 0;
                    int countValue = productViewModel.Products.Count;
                    foreach (var p in productViewModel.Products)
                    {
                        count++;
                        if (p.ProductName == model.ProductName)
                        {
                            p.TotalCostPrice += model.TotalCostPrice;
                            p.SalesPrice += model.SalesPrice;
                            p.Profit += model.Profit;
                            break;
                        }
                        else
                        {
                            if (count == countValue)
                            {
                                aModel.ProductCode = model.ProductCode;
                                aModel.ProductName = model.ProductName;
                                aModel.CategoryName = model.CategoryName;
                                aModel.TotalCostPrice = model.TotalCostPrice;
                                aModel.SalesPrice = model.SalesPrice;
                                aModel.Profit = model.Profit;
                                productViewModel.Products.Add(aModel);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    aModel.ProductCode = model.ProductCode;
                    aModel.ProductName = model.ProductName;
                    aModel.CategoryName = model.CategoryName;
                    aModel.TotalCostPrice = model.TotalCostPrice;
                    aModel.SalesPrice = model.SalesPrice;
                    aModel.Profit = model.Profit;
                    productViewModel.Products.Add(aModel);
                }

            }
            return View(productViewModel);
        }
    }
}