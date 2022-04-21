using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using TeamProjectJoole.Models;
using Joole.Service;

namespace TeamProjectJoole.Controllers
{
    public class HomeController : Controller
    {

        //MapperConfiguration config;
        //IMapper mapper;
        //ProductsService productService;

        //public HomeController()
        //{
        //    productService = new ProductsService();
        //}

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Products()
        {
            return View();
        }

        public ActionResult Create()
        {
            var result = new ProductServices().getAllProducts();
            ProductInfoVM productInfoVM = new ProductInfoVM();
            ProductInfoVM productInfoVM2 = new ProductInfoVM();
            List<ProductInfoVM> productList = new List<ProductInfoVM>();

            productInfoVM.ProductIDs = 101;
            productInfoVM.Product_Name = "Wall";

            productList.Add(productInfoVM);

            productInfoVM2.ProductIDs = 202;
            productInfoVM2.Product_Name = "Floor";

            productList.Add(productInfoVM2);
            //foreach (var item in productInfoVM)
            //{ 

            //}

            foreach(var item in result)
            {
                ProductInfoVM vm = new ProductInfoVM();
                vm.ProductIDs = item.Product_ID;
                vm.Product_Name = item.Product_Name;
                productList.Add(vm);
            }

            return View("Create", productList);

        }

    }
}