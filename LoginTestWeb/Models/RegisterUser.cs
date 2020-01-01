using LoginTestWeb.ModelBinder;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoginTestWeb.Models
{
    public class RegisterUser
    {

        [Key]
        public string userid { get; set; }
        [Required]
        [EmailAddress]
        [EmailValidator(allowedDomain:"gmail.com",ErrorMessage ="Domain name must be gmail.com")]
        public string Email { get; set; }
        [Required]
        [MaxLength(10)]
        public string contactno { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Required]
        [Compare("password",ErrorMessage ="Passwords do not match")]
        public string confirmpassword { get; set; }
        [Required]
        
        public string Gender { get; set; }
        [Required]
        public string City { get; set; }
    }
}
