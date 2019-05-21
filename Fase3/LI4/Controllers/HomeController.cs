using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LI4.Models;

namespace LI4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
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