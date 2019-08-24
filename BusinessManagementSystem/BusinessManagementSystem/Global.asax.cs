using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BusinessManagementSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<SalesSaveViewModel, SalesDetails>();
            //    cfg.CreateMap<SalesDetails, SalesSaveViewModel>();
            //    cfg.CreateMap<SalesSaveViewModel, CustomerModel>();
            //    cfg.CreateMap<CustomerModel, SalesSaveViewModel>();
            //    cfg.CreateMap<SalesSaveViewModel, Sale>();
            //    cfg.CreateMap<Sale, SalesSaveViewModel>();
            //    cfg.CreateMap<SalesSaveViewModel, Product>();
            //    cfg.CreateMap<Product, SalesSaveViewModel>();
            //});
        }
    }
}
