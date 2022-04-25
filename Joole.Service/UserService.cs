using Joole.Data.Data;
using Joole.Repo;
using Joole.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joole.Service
{
    
    public class UserService
    {
        public UnitOfWork uow { get; set; }
        public JooleDBEntities jooleDBEntities;

        public UserService()
        {
            this.jooleDBEntities = new JooleDBEntities();
            this.uow = new UnitOfWork(jooleDBEntities);
        }

        public void UserSignup(UserDTO userDTO)
        {
            tblUser obj = new tblUser()
            {
                //User_ID = userDTO.UserId,
                User_Name = userDTO.UserName,
                User_Password = userDTO.UserPassword

            };
            uow.Users.Add(obj);
            uow.Complete();
        }

        public UserDTO UserLogin(string username, string userpassword)
        {

            IEnumerable<tblUser> users = uow.Users.GetAll();
            UserDTO userDTO;

            foreach (tblUser user in users)
            {
                if (user.User_Name == username &&
                    user.User_Password == userpassword)
                {
                    userDTO = new UserDTO()
                    {
                        //UserId = user.User_ID,
                        UserName = user.User_Name,
                        UserPassword = user.User_Password
                    };
                    return userDTO;
                }
            }



            return null;

        }


    }
}
