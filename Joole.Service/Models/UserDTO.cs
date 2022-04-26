using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joole.Service.Models
{
    public class UserDTO
    {
        // TODO: check if user signup and login still work when UserId part is uncommented.
        // (there is a potential conflict with auto-increment in db)
        public int UserId { get; set; }
        public string UserName { get; set; }

        public string UserPassword { get; set; }
    }
}
