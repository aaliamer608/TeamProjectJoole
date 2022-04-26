using Joole.Data.Data;
using Joole.Repo;
using Joole.Repo.Repositories;
using Joole.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joole.Service
{
    

   public  class FeedbackServices
    {
        public UnitOfWork uow { get; set; }
        public JooleDBEntities jooleDBEntities;

        public FeedbackServices()
        {
            this.jooleDBEntities = new JooleDBEntities();
            this.uow = new UnitOfWork(jooleDBEntities);
        }


        public List<tblFeedback> getAllFeedbacks() 
        {


            return (List<tblFeedback>)uow.Feedbacks.GetAll();
        }

        public void addFeedback(FeedbackDTO feedbackDTO)
        {
            int user_id = uow.Users.GetIdByName(feedbackDTO.User_Name);

            tblFeedback obj = new tblFeedback()
            {
                
                User_ID = user_id,
                FeedBack_Content = feedbackDTO.Feedback_Content


            };
            uow.Feedbacks.Add(obj);
            uow.Complete();
        }
    }
}
