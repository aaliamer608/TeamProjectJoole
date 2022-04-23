using Joole.Data.Data;
using Joole.Repo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joole.Service
{
    

   public  class FeedbackServices
    {
        JooleDBEntities _context;
        GenericRepository<tblFeedback> genRepo;
        public FeedbackServices()
        {
            _context = new JooleDBEntities();
            
            genRepo = new GenericRepository<tblFeedback>(_context); 

        }


        public List<tblFeedback> getAllProducts() 
        {
            

            return genRepo.GetAll().ToList();
        }
    }
}
