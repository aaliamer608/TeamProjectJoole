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


    public class TypeFilterServices
    {
        public UnitOfWork uow { get; set; }
        public JooleDBEntities jooleDBEntities;

        public TypeFilterServices()
        {
            this.jooleDBEntities = new JooleDBEntities();
            this.uow = new UnitOfWork(jooleDBEntities);

        }

    }
}
