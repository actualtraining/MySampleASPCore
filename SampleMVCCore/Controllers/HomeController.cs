using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleMVCCore.Models;
using MyLibrary;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace SampleMVCCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public HomeController(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task CreateUser()
        {
            var user1 = new ApplicationUser { UserName = "budi@gmail.com", Email = "budi@gmail.com" };
            var user2 = new ApplicationUser { UserName = "bambang@gmail.com", Email = "bambang@gmail.com" };

            //string randPass = Guid.NewGuid().ToString().Substring(0, 5);
            await _userManager.CreateAsync(user1, "rahasia");
            await _userManager.CreateAsync(user2, "rahasia");
            //email ke user

        }

        public async Task<IActionResult> Index()
        {
            await CreateUser();
            return View();
        }

        [Authorize]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

       
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
