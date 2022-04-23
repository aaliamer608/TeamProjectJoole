using Joole.Data.Data;
using Joole.Repo;
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
        public UnitOfWork uow { get; set; }
        public JooleDBEntities _context;

        GenericRepository<tblCategory> genRepo;
        public CategoryServices()
        {
            _context = new JooleDBEntities();
            
            genRepo = new GenericRepository<tblCategory>(_context); 

        }


        //public List<tblCategory> getAllProducts() 
        //{


        //    return genRepo.GetAll().ToList();
        //}

        public List<tblCategory> getAllProducts()
        {
            tblCategory obj = new tblCategory()
            {

            };
            var res = uow.Categories.GetAll();
            uow.Complete();
            return (List<tblCategory>)res;
        }
    }
}