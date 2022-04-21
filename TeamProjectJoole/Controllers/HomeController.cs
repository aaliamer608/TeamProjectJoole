using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using AutoMapper;

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
            return View();
        }

    }
}