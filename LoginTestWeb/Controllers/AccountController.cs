using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginTestWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LoginTestWeb.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(SignInManager<ApplicationUser> signInManager,UserManager<ApplicationUser> userManager)
        {
            SignInManager = signInManager;
            UserManager = userManager;
        }

        public SignInManager<ApplicationUser> SignInManager { get; }
        public UserManager<ApplicationUser> UserManager { get; }
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginModel model, string ReturnUrl)
        {
            
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(ReturnUrl))
                {
                    var result = await SignInManager.PasswordSignInAsync(model.username, model.password, model.rememberme, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index","Employee");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid Username or Password");
                    }
                }
                else
                {
                    var result = await SignInManager.PasswordSignInAsync(model.username, model.password, model.rememberme, false);
                    if (result.Succeeded)
                    {
                        return LocalRedirect(ReturnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid Username or Password");
                    }

                }
            }
            return View();
        }
    }
}