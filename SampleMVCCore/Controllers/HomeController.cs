using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleMVCCore.Models;
using MyLibrary;
using Microsoft.AspNetCore.Identity;

namespace SampleMVCCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public HomeController(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {

        }

        public IActionResult Index()
        {
            Movie m1 = new Movie { ID = 1, Genre = "Horror" };
            Movie m2 = m1;
            m1.Genre = "Comedy";

            ViewData["Genre1"] = m1.Genre;
            ViewData["Genre2"] = m2.Genre;
            return View();
        }

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
