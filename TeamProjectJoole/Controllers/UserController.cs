using AutoMapper;
using Joole.Service;
using Joole.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TeamProjectJoole.Models;

namespace TeamProjectJoole.Controllers
{
    public class UserController : Controller
    {
        MapperConfiguration config;
        IMapper mapper;
        UserService userService;

        public UserController()
        {
            userService = new UserService();
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDTO, UserModel>();
            }
            );
            mapper = config.CreateMapper();
        }

        // GET: User
        public ActionResult Index()
        {
            return View("Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserModel model)
        {
           
            UserDTO userDTO = userService.UserLogin(model.UserName, model.UserPassword);

            if (userDTO != null)
            {
                FormsAuthentication.SetAuthCookie(model.UserName, false);
                return RedirectToAction("Index", "Product");
            }
            ModelState.AddModelError("loginFail", "Invalid user name or password");
            return View();
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(UserModel model)
        {
            userService.UserSignup(new UserDTO
            {
                //UserId = model.UserId,
                UserName = model.UserName,
                UserPassword = model.UserPassword
            });
            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}