using Joole.Data.Data;
using Joole.Repo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joole.Service
{
    

   public  class CategoryServices
    {
        JooleDBEntities _context;
        GenericRepository<tblCategory> genRepo;
        public CategoryServices()
        {
            _context = new JooleDBEntities();
            
            genRepo = new GenericRepository<tblCategory>(_context); 

        }


        public List<tblCategory> getAllProducts() 
        {
            

            return genRepo.GetAll().ToList();
        }
    }
}
