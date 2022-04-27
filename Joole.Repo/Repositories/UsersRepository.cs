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

        public int GetIdByName(string username)
        {
            IEnumerable<tblUser> listUsers = this.GetAll();


                foreach (tblUser user in listUsers)
                {
                    if (user.User_Name == username)
                        return user.User_ID;
                }

            return -1;
            
        }

    }
}
