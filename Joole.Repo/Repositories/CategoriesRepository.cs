using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Joole.Data.Data;

namespace Joole.Repo.Repositories
{

    public class CategoriesRepository : GenericRepository<tblCategory>, ICategoriesRepository
    {
        public CategoriesRepository(JooleDBEntities jooleDBEntities) : base(jooleDBEntities) 
        { 

        }

        public int AddCategory(tblCategory category)
        {
            IEnumerable<tblCategory> listCategories = this.GetAll();
            int catId = -1;

            foreach (tblCategory cat in listCategories)
            {
                if (cat.Category_Name == category.Category_Name)
                {
                    catId = cat.Category_ID;
                    return catId;
                }
                    
            }
            // there is no matching category
            this.Add(category);
            return catId;
        }


        //public JooleDBEntities JooleDBEntities { get { return Context as JooleDBEntities; } }
    }

}
