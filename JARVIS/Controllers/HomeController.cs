using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JARVIS.Models;

namespace JARVIS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View("Login");
        }

        public ActionResult Register()
        {
            return View();
        }

        public IActionResult Pantry()
        {
            ViewData["Message"] = "Your application description page.";

            return View("Pantry");
        }

        public IActionResult WeekPlan()
        {
            ViewData["Message"] = "Your application description page.";

            return View("WeekPlan");
        }

        public IActionResult Cookbook()
        {
            ViewData["Message"] = "Your application description page.";

            return View("Cookbook");
        }

        public IActionResult ShoppingList()
        {
            ViewData["Message"] = "Your application description page.";

            return View("ShoppingList");
        }

    }
}