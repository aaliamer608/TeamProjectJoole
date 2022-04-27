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
        public JooleDBEntities jooleDBEntities;

        public CategoryServices()
        {
            this.jooleDBEntities = new JooleDBEntities();
            this.uow = new UnitOfWork(jooleDBEntities);

        }



        public List<tblCategory> getAllCategories()
        {
            var res = uow.Categories.GetAll();
            return (List<tblCategory>)res;
        }

        public tblCategory getByCategory_ID(int id)
        {
            var res = uow.Categories.GetById(id);

            return res;

        }
    }
}