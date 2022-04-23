using Joole.Data.Data;
using Joole.Repo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joole.Service
{
    

   public  class ProductServices
    {
        JooleDBEntities _context;
        GenericRepository<tblProduct> genRepo;
        public ProductServices()
        {
            _context = new JooleDBEntities();
            
            genRepo = new GenericRepository<tblProduct>(_context); 

        }


        public List<tblProduct> getAllProducts() 
        {
            

            return genRepo.GetAll().ToList();
        }
    }
}
