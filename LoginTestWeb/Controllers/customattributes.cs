using LoginTestWeb.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginTestWeb.Controllers
{
    public class CustomEmployeeAttribute:ActionFilterAttribute,IActionFilter
    {
        
        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {
            HeroesContext Context = new HeroesContext();
            Employees employees = new Employees { EmpName= "ActionExecutedContext", EmpSalary=10000,PhotoPath="workedpath"};
            Context.Employees.Add(employees);
            Context.SaveChanges();            
        }
        void IActionFilter.OnActionExecuting(ActionExecutingContext context)
        {
            HeroesContext Context = new HeroesContext();
            Employees employees = new Employees { EmpName = "ActionExecutingContext", EmpSalary = 20000, PhotoPath = "workingpath" };
            Context.Employees.Add(employees);
            Context.SaveChanges();
        }
    }
}
