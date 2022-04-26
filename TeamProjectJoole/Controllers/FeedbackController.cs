using AutoMapper;
using Joole.Service;
using Joole.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamProjectJoole.Models;

namespace TeamProjectJoole.Controllers
{
    public class FeedbackController : Controller
    {
        MapperConfiguration config;
        IMapper mapper;
        FeedbackServices feedbackService;

        public FeedbackController()
        {
            feedbackService = new FeedbackServices();
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FeedbackDTO, FeedbackInfoVM>();
            }
            );
            mapper = config.CreateMapper();
        }


        // GET: Feeback
        public ActionResult Index()
        {
            return RedirectToAction("Feedback");
        }

        public ActionResult Feedback()
        {

            var result_feedback = new FeedbackServices().getAllFeedbacks();
            List<FeedbackInfoVM> feedbackList = new List<FeedbackInfoVM>();

            var result_users = new UserService().getAllUsersDTOs();
            var result_products = new ProductServices().getAllProducts();

            foreach (var item in result_feedback)
            {
                FeedbackInfoVM feedbackVM = new FeedbackInfoVM();
                feedbackVM.Feedback_ID = item.FeedBack_ID;
                feedbackVM.Feedback_Content = item.FeedBack_Content;

                var user_id = item.User_ID;
                string user_name = "N/A";
                foreach (var user in result_users)
                {
                    if (user.UserId == user_id)
                    {
                        user_name = user.UserName;
                    }
                }
                feedbackVM.User_Name = user_name;

                feedbackList.Add(feedbackVM);
            }

            return View("Feedback", feedbackList);
        }

        // TODO: create a view page based on FeedbackInfoVM
        public ActionResult CreateFeedback()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateFeedback(FeedbackInfoVM feedbackInfoVM)
        {
            // TODO: like signup, save the data got from user to db
            feedbackService.addFeedback(new FeedbackDTO
            {
                User_Name = User.Identity.Name,
                Feedback_Content = feedbackInfoVM.Feedback_Content
            });
           

            // displays list of feedbacks
            return RedirectToAction("Feedback");
        }
    }
}