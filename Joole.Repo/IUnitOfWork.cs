using Joole.Repo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joole.Repo
{
    public partial interface IUnitOfWork : IDisposable
    {
        IUsersRepository Users { get; }
        IProductsRepository Products { get; }
        ICategoriesRepository Categories { get; }
        //ITypeFilterRepository TypeFilter { get; }
        IFeedbackRepository Feedbacks { get; }
        ISubCategoryRepository SubCategories { get; }

        IPropertiesRepository Properties { get; }

        IPropertyValuesRepository PropertyValues { get; }
        int Complete();
    }
}
