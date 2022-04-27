using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Joole.Data.Data;

namespace Joole.Repo.Repositories
{

    public class PropertiesRepository : GenericRepository<tblProperty>, IPropertiesRepository
    {
        public PropertiesRepository(JooleDBEntities jooleDBEntities) : base(jooleDBEntities) 
        { 

        }

        public int AddProperty(tblProperty property)
        {
            IEnumerable<tblProperty> listProperty = this.GetAll();
            int propID = -1;

            foreach (tblProperty prop in listProperty)
            {
                if (prop.Property_Name == property.Property_Name)
                {
                    propID = prop.Property_ID;
                    return propID;
                }

            }
            // there is no matching property
            this.Add(property);
            return propID;
        }

        //public JooleDBEntities JooleDBEntities { get { return Context as JooleDBEntities; } }
    }

}
