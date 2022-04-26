using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamProjectJoole.Models
{
    public class FeedbackInfoVM
    {
        public int Feedback_ID { get; set; }

        public string Feedback_Content{ get; set; }

        public string Product_Name { get; set; }

        public string User_Name { get; set; }


    }
}