﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JARVIS.Models;
using JARVIS.DataAccess;

namespace JARVIS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
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