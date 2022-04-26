using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamProjectJoole.Models
{
    public class ProductInfoVM
    {
        public int? ProductID { get; set; }

        public string Product_Name { get; set; }

        public int? SubCategory_ID { get; set; }

        public string Subcategory_Name { get; set; }

        public int? Category_ID { get; set; }

        public string Category_Name { get; set; }

        //public List<ProductInfoVM> productList = new List<ProductInfoVM>();

    }
}