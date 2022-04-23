using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Joole.Data.Data;

namespace Joole.Repo.Repositories
{

    public class FeedbackRepository : GenericRepository<tblFeedback>, IFeedbackRepository
    {
        public FeedbackRepository(JooleDBEntities jooleDBEntities) : base(jooleDBEntities) 
        { 

        }


    //    public JooleDBEntities JooleDBEntities { get { return Context as JooleDBEntities; } }
    }

}
