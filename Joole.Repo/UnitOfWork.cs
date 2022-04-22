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
        private readonly JooleDBEntities context;

        // Member variables are loosely coupled by using interfaces
        public IUsersRepository Users { get; set; }


        // Member variables get their particular types here
        public UnitOfWork(JooleDBEntities context)
        {
            this.context = context;
            this.Users = new UsersRepository(context);
        }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
