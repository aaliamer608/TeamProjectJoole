using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joole.Service.Models
{
    public class FeedbackDTO
    {
        public int Feedback_ID { get; set; }

        public string User_Name { get; set; }

        public string Feedback_Content { get; set; }
    }
}
