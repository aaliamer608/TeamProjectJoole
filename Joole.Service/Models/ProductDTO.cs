using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joole.Service.Models
{
    public class ProductDTO
    {

        public int? ProductID { get; set; }

        public string Product_Name { get; set; }

        public string Product_img_url { get; set; }

        public string Category_Name { get; set; }

        public string Subcategory_Name { get; set; }

        public string prop_name1 { get; set; }

        public int prop_val1 { get; set; }

        public string prop_name2 { get; set; }

        public int prop_val2 { get; set; }
    }
}
