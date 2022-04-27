using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Joole.Data.Data;

namespace Joole.Repo.Repositories
{

    public class ProductsRepository : GenericRepository<tblProduct>, IProductsRepository
    {
        public ProductsRepository(JooleDBEntities jooleDBEntities) : base(jooleDBEntities) 
        { 

        }

        public int AddProduct(tblProduct product)
        {
            tblProduct savedProduct = this.context.Set<tblProduct>().Add(product);
            return savedProduct.Product_ID;
        }

    }

}
