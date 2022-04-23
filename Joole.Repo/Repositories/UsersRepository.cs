using Joole.Data.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joole.Repo.Repositories
{
    public class UsersRepository : GenericRepository<tblUser>, IUsersRepository
    {
        public UsersRepository(JooleDBEntities jooleDBEntities) : base(jooleDBEntities)
        {
        }

        //public JooleDBEntities JooleDBEntities { get { return context as JooleDBEntities; } }

    }
}
