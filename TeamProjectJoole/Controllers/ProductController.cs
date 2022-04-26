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
        [HttpPost]
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
            var result = categoryService.getAllCategories();

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
