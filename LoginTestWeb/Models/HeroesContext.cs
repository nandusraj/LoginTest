using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginTestWeb.Models;

namespace LoginTestWeb.Models
{
    public class HeroesContext:IdentityDbContext<ApplicationUser>
    {
        public HeroesContext()
        {
        }
        public HeroesContext(DbContextOptions<HeroesContext> options)  : base(options)
        {
            
        }    

        public virtual DbSet<Department> Department { get; set; }
        
        public virtual DbSet<Employees> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<LoginTestWeb.Models.RegisterUser> RegisterUser { get; set; }
        public DbSet<LoginTestWeb.Models.RoleModel> RoleModel { get; set; }
        

    }    
}
