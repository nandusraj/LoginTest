using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoginTestWeb.Models
{
    public class RoleModel

    {
        [Key]
        public string roleid { get; set; }
        [Required]
        public string role { get; set; }
    }
}
