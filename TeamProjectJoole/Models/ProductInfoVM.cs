using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamProjectJoole.Models
{
    public class ProductInfoVM
    {
        [Display(Name = "Product ID")]
        public int? ProductID { get; set; }
        [Display(Name = "Product Name")]
        public string Product_Name { get; set; }

        [Display(Name ="Product image url link")]
        public string Product_img_url { get; set; }

        //public int? Category_ID { get; set; }
        [Display(Name = "Category Name")]
        public string Category_Name { get; set; }

        //public int? SubCategory_ID { get; set; }
        [Display(Name = "Sub-category name")]
        public string Subcategory_Name { get; set; }

        [Display(Name = "First property name (e.g. length, weight)")]
        public string prop_name1 { get; set; }

        [Display(Name = "First property value (numbers only)")]
        public int prop_val1 { get; set; }

        [Display(Name = "Second property name (e.g. length, weight)")]
        public string prop_name2 { get; set; }

        [Display(Name = "Second property value (numbers only)")]
        public int prop_val2 { get; set; }


        //public List<ProductInfoVM> productList = new List<ProductInfoVM>();

    }
}