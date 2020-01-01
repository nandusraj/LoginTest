using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginTestWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LoginTestWeb.Controllers
{
    public class AdministrationController : Controller
    {
        public AdministrationController(RoleManager<IdentityRole> roleManager)
        {
            RoleManager = roleManager;
        }

        public RoleManager<IdentityRole> RoleManager { get; }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(RoleModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = model.role
                };

                var result = await RoleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Employee");
                }
                else
                {
                    ModelState.AddModelError(string.Empty,"Could not create role");
                }
            }
            return View();

        }

        public ActionResult ListRoles()
        {
            var roles = RoleManager.Roles;
            return View(roles);
        }
    }
}