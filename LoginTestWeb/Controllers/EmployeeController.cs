using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginTestWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using Microsoft.Extensions.Caching.Memory;
using PagedList;
using PagedList.Mvc;

namespace LoginTestWeb.Controllers
{
    public class EmployeeController : Controller
    {
        public HeroesContext _Context { get; }
        public UserManager<ApplicationUser> UserManager { get; }
        public SignInManager<ApplicationUser> SignInManager { get; }
        private IMemoryCache cache;
        ConnectionMultiplexer con = ConnectionMultiplexer.Connect("localhost");
        private IDatabase db;
        public EmployeeController(HeroesContext _context,UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager,IMemoryCache _cache)
        {
            IDatabase db = con.GetDatabase();
            cache = _cache;
            _Context = _context;
            UserManager = userManager;
            SignInManager = signInManager;
        }
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public  ActionResult Create(Employees employee)
        {
            
            if (ModelState.IsValid)
            {
                _Context.Employees.Add(employee);
                _Context.SaveChanges();
                //cache.Set("EmployeeCache",_Context.Employees.ToList());

                return RedirectToAction("Index");
            }
            return View();
        }


        
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Register(RegisterUser registerUser)
        {
            if(ModelState.IsValid)
            {
                var user = new ApplicationUser {UserName=registerUser.Email,PhoneNumber=registerUser.contactno,Email=registerUser.Email ,city=registerUser.City,gender=registerUser.Gender};
                var result= await UserManager.CreateAsync(user,registerUser.password);
                if (result.Succeeded)
                {
                    
                    return RedirectToAction("Index");

                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("",error.Description);
                    }
                }
            }
            return View();
            
            
        }
        [HttpPost]
        public async Task<ActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Index");
        }


        // GET: Employee
        [CustomEmployee]
        public ActionResult Index(int? page)
        {            
            return View(_Context.Employees.ToList().ToPagedList(page ?? 1, 2));
        }

        public PartialViewResult Filter()
        {
            List<Employees> employees=_Context.Employees.ToList();
            employees.Sort();
            return PartialView(employees);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        

        // POST: Employee/Create
        

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

    }
}