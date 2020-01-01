using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoginTestWeb.Models
{
    public class Employees
    {
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public long? EmpSalary { get; set; }
        public int? DeptId { get; set; }
        public string PhotoPath { get; set; }

        public Department Dept { get; set; }
    }
}
