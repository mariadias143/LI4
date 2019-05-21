using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LI4.Models;
using LI4.Views.Shared;
using static LI4.Models.Utilizador;

namespace LI4.Controllers
{
    public class UserController : Controller
    {
        private UserHandling userHandling;
        public UserController(UserContext context)
        {
            userHandling = new UserHandling(context);
        }
        [HttpGet]
        public Utilizador[] Get()
        {
            return userHandling.getUsers();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }


    }
}
