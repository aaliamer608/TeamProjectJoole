using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using TeamProjectJoole.Models;
using Joole.Service;
using Joole.Service.Models;

namespace TeamProjectJoole.Controllers
{
    public class ProductController : Controller
    {
        MapperConfiguration config;
        IMapper mapper;
        ProductServices productsService;
        CategoryServices categoryService;

        public ProductController()
        {
            productsService = new ProductServices();
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductDTO, ProductInfoVM>();
                cfg.CreateMap<CategoryDTO, CategoryInfoVM>();
            }
            );
            mapper = config.CreateMapper();
        }

        public ActionResult Index()
        {
            List<ProductInfoVM> productList = new List<ProductInfoVM>();

            return View("Products", productList);
        }

        public ActionResult Search(string searchString)
        {
            //string name = "hammer";
            var result = productsService.getProductByName(searchString);
            List<ProductInfoVM> productList = new List<ProductInfoVM>();

            foreach (var item in result)
            {
                ProductInfoVM productVM = new ProductInfoVM();
             //   productVM.ProductID = item.Product_ID;
                productVM.Product_Name = item.Product_Name;

                productList.Add(productVM);
            }

            return View("Search", productList);
        }

        public ActionResult Products()
        {

            var result = productsService.getAllProducts();
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
            categoryService = new CategoryServices();
            //var result = new CategoryServices().getAllProducts();
            var result = categoryService.getAllProducts();

            List<CategoryInfoVM> categoryList = new List<CategoryInfoVM>();

            foreach(var item in result)
            {
                CategoryInfoVM vm = new CategoryInfoVM();
                vm.CategoryID = item.Category_ID;
                vm.Category_Name = item.Category_Name;
                categoryList.Add(vm);
            }

            IEnumerable<CategoryInfoVM> categoryEn = categoryList;


            return View("Types", categoryEn);
        }


        public ActionResult Feedback()
        {

            var result_feedback = new FeedbackServices().getAllProducts();
            List<FeedbackInfoVM> feedbackList = new List<FeedbackInfoVM>();

            var result_users = new UserService().getAllUsers();
            var result_products = new ProductServices().getAllProducts();

            foreach (var item in result_feedback)
            {
                FeedbackInfoVM feedbackVM = new FeedbackInfoVM();
                feedbackVM.Feedback_ID = item.FeedBack_ID;
                feedbackVM.Feedback_Content= item.FeedBack_Content;

                var user_id = item.User_ID;
                string user_name = "N/A";
                foreach (var user in result_users)
                {
                    if (user.UserId == user_id)
                    {
                        user_name = user.UserName;
                    }
                }

                var product_id = item.Product_ID;
                string product_name = "N/A";
                foreach (var product in result_products)
                {
                    if (product.Product_ID == product_id)
                    {
                        product_name = product.Product_Name;
                    }
                }

                feedbackVM.User_Name = user_name;
                feedbackVM.Product_Name = product_name;
                
                






                feedbackList.Add(feedbackVM);
            }

            return View("Feedback", feedbackList);
        }


        //public ActionResult Types()
        //{

        //    var result = new TypeFilterServices().getAllProducts();
        //    List<TypeFilterInfoVM> typeFilterList = new List<TypeFilterInfoVM>();

        //    foreach (var item in result)
        //    {
        //        TypeFilterInfoVM typeFilterVM = new TypeFilterInfoVM();
        //        typeFilterVM.Property_ID = (int)item.Property_ID;
        //        typeFilterVM.Type_name= item.Type_name;

        //        typeFilterList.Add(typeFilterVM);
        //    }

        //    return View("Types", typeFilterList);
        //}

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductInfoVM model)
        {
            var res = new ProductServices();
            if (ModelState.IsValid)
            {
                
                res.productAdd(new ProductDTO
                {
                    //ProductId = model.ProductID,
                    Product_Name = model.Product_Name
                });
            }
            //productsService = new ProductServices();
            //productsService.productAdd(new ProductDTO
            //{
            //    ProductId = model.ProductID,
            //    Product_Name = model.Product_Name
            //});
            return RedirectToAction("Products");
        }
    }
}
