using Joole.Data.Data;
using Joole.Repo;
using Joole.Repo.Repositories;
using Joole.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joole.Service
{

    public class ProductServices
    {
        public UnitOfWork uow { get; set; }
        public JooleDBEntities _context;

        public ProductServices()
        {

            this._context = new JooleDBEntities();
            this.uow = new UnitOfWork(_context);
        }


        public int ProductAdd(ProductDTO productDTO)
        {
            // save tblCategory if new
            int catID = uow.Categories.AddCategory(new tblCategory { Category_Name = productDTO.Category_Name });

            // save tblSubCategory if new
            int subCatID = uow.SubCategories.AddSubCategory(new tblSubCategory { Category_ID = catID, 
                                                                                 SubCategory_Name = productDTO.Subcategory_Name});

            // save tblProduct
            tblProduct tblProduct = new tblProduct()
            {
                Product_Name = productDTO.Product_Name,
                Product_Image = productDTO.Product_img_url,
                SubCategory_ID = subCatID,
                Category_ID = catID
            };
            int productID = uow.Products.AddProduct(tblProduct);

            // save tblProperty
            // TODO: make it like code above
            List<int> propIds = new List<int>();
            List<string> propNames = new List<string> { productDTO.prop_name1, productDTO.prop_name2 };

            foreach (string propName in propNames)
            {
                tblProperty property = new tblProperty()
                {
                    Property_Name = propName
                };

                propIds.Add(uow.Properties.AddProperty(property));

            }

            // save tblPropertyValues
            List<int> propVals = new List<int> { productDTO.prop_val1, productDTO.prop_val2 };

            for (int i = 0; i < 2; i++)
            {
                if (propIds[i] > 0)
                {
                    tblPropertyValue tblPropVal = new tblPropertyValue
                    {
                        Property_ID = propIds[i],
                        Product_ID = productID,
                        Value = propVals[i]
                    };
                    uow.PropertyValues.Add(tblPropVal);
                }
                    
                
            }

            uow.Complete();

            return productID;
        }


        public List<tblProduct> getAllProducts()
        {

            var res = uow.Products.GetAll();
            //uow.Complete();
            return (List<tblProduct>)res;
        }


        public IEnumerable<ProductDTO> getProductByName(string name)
        {
            var product = uow.Products.GetAll();

            var result = (
                from p in product
                where p.Product_Name.Equals(name, StringComparison.OrdinalIgnoreCase)
                select new ProductDTO
                {
                    //ProductId = p.Product_ID,
                    Product_Name = p.Product_Name
                }
                ).ToList();

            //uow.Complete();

            return result;
        }

    }
}
