using Joole.Data.Data;
using Joole.Repo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joole.Repo
{
    public partial class UnitOfWork : IUnitOfWork
    {
        private readonly JooleDBEntities _context;
        public UnitOfWork(JooleDBEntities context)
        {
            _context = context;
            Users = new UsersRepository(_context);
            Products = new ProductsRepository(_context);
            Categories = new CategoriesRepository(_context);
            SubCategories = new SubCategoryRepository(_context);
            Feedbacks = new FeedbackRepository(_context);
            //Types = new TypeFilterRepository(_context);
            //Departments = new DepartmentsRepository(_context);
        }



        // Member variables are loosely coupled by using interfaces
        public IUsersRepository Users { get; set; }

        public IProductsRepository Products { get; set; }

        public ICategoriesRepository Categories { get; set; }

        public ISubCategoryRepository SubCategories { get; set; }

        public IFeedbackRepository Feedbacks { get; set; }


        // Member variables get their particular types here
        //public UnitOfWork(JooleDBEntities context)
        //{
        //    this.context = context;
        //    this.Users = new UsersRepository(context);
        //}

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
