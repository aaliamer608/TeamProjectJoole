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
    public class SubCategoryServices
    {
        public UnitOfWork uow { get; set; }
        public JooleDBEntities jooleDBEntities;

        public SubCategoryServices()
        {
            this.jooleDBEntities = new JooleDBEntities();
            this.uow = new UnitOfWork(jooleDBEntities);

        }



        public List<tblSubCategory> getAllSubCategories()
        {
            
            var res = uow.SubCategories.GetAll();
            //uow.Complete();
            return (List<tblSubCategory>)res;
        }

        public tblSubCategory getBySubCategory_ID(int id)
        {
            tblSubCategory res = uow.SubCategories.GetById(id);

            return res;

        }
    }
}
