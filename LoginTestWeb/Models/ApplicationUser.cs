using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LoginTestWeb.Models
{
    
    public class ApplicationUser:IdentityUser
    {
        public string gender { get; set; }
        public string city { get; set; }
    }
}
