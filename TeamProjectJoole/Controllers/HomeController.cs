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
    //This is different
    public class HomeController : Controller
    {
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

            var result = new ProductServices().getAllProducts();
            List<ProductInfoVM> productList = new List<ProductInfoVM>();

            foreach (var item in result)
            {
                ProductInfoVM productVM = new ProductInfoVM();
                productVM.ProductID = item.Product_ID;
                productVM.Product_Name = item.Product_Name;

                productList.Add(productVM);
            }

            return View("Products", productList);
        }

        public ActionResult Categories()
        {
            var result = new CategoryServices().getAllProducts();
            List<CategoryInfoVM> categoryList = new List<CategoryInfoVM>();

            foreach(var item in result)
            {
                CategoryInfoVM vm = new CategoryInfoVM();
                vm.CategoryID = item.Category_ID;
                vm.Category_Name = item.Category_Name;
                categoryList.Add(vm);
            }

            return View("Categories", categoryList);

        }


        public ActionResult Feedback()
        {

            var result = new FeedbackServices().getAllProducts();
            List<FeedbackInfoVM> feedbackList = new List<FeedbackInfoVM>();

            foreach (var item in result)
            {
                FeedbackInfoVM feedbackVM = new FeedbackInfoVM();
                feedbackVM.Feedback_ID = item.FeedBack_ID;
                feedbackVM.Feedback_Content= item.FeedBack_Content;

                feedbackList.Add(feedbackVM);
            }

            return View("Feedback", feedbackList);
        }

    }
}