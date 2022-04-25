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
        //public int UserId { get; set; }
        [Required(ErrorMessage = "Please provide user name", AllowEmptyStrings = false)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please provide password", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
    }
}