using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Joole.Data.Data;

namespace Joole.Repo.Repositories
{

    public class SubCategoryRepository : GenericRepository<tblSubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(JooleDBEntities jooleDBEntities) : base(jooleDBEntities) 
        { 

        }

        public int AddSubCategory(tblSubCategory subCategory)
        {
            IEnumerable<tblSubCategory> tblSubCategories = this.GetAll();
            int subCatId = -1;

            foreach (tblSubCategory cat in tblSubCategories)
            {
                if (cat.Category_ID == subCategory.Category_ID
                    && cat.SubCategory_Name == subCategory.SubCategory_Name)
                {
                    subCatId = cat.Category_ID;
                    return subCatId;
                }

            }

            // there is no matching subcategory
            this.Add(subCategory);
            return subCatId;
        }
    }

}
