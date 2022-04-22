using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TeamProjectJoole.Models
{
    public class UserModel
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    }
}