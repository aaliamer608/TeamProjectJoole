using Joole.Data.Data;
using Joole.Repo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joole.Service
{


    public class TypeFilterServices
    {
        JooleDBEntities _context;
        GenericRepository<tblTypeFilter> genRepo;
        public TypeFilterServices()
        {
            _context = new JooleDBEntities();

            genRepo = new GenericRepository<tblTypeFilter>(_context);

        }


        public List<tblTypeFilter> getAllTypeFilters()
        {


            return genRepo.GetAll().ToList();
        }
    }
}
