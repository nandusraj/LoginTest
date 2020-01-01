using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoginTestWeb.Models
{
    public class LoginModel
    {
        [Display(Name ="Email")]
        [Required]
        public string username { get; set; }
        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Display(Name = "Remember me")]
        public bool rememberme { get; set; }
    }
}
