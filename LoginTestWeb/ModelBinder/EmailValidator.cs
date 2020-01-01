using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoginTestWeb.ModelBinder
{
    public class EmailValidatorAttribute:ValidationAttribute
    {
        public EmailValidatorAttribute(string allowedDomain)
        {
            AllowedDomain = allowedDomain;
        }

        private string AllowedDomain;

        public override bool IsValid(object value)
        {
            string[] domain=value.ToString().Split("@");
            return domain[1] == AllowedDomain;
        }
    }
}
