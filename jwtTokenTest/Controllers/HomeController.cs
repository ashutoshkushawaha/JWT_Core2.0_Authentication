using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using jwtTokenTest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;

namespace jwtTokenTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _config;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;


        public HomeController(IConfiguration configuration, UserManager<ApplicationUser> userManager,
           SignInManager<ApplicationUser> signInManager)
        {
            _config = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        // private readonly IConfiguration _config;
        //private readonly UserManager<IdentityUser> _userManager;
        //private readonly SignInManager<IdentityUser> _signInManager;


        //public HomeController(UserManager<IdentityUser> userManager,
        //   SignInManager<IdentityUser> signInManager)
        //{
        //    //_config = configuration;
        //    _userManager = userManager;
        //    _signInManager = signInManager;
        //}
        public IActionResult Index()
        {
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
