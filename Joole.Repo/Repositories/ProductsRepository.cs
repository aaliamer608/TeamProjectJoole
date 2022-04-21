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
        public ProductsRepository(JooleDBEntities productsDBEntities) : base(productsDBEntities) 
        { 

        }


        public JooleDBEntities JooleDBEntities { get { return Context as JooleDBEntities; } }
    }

}
