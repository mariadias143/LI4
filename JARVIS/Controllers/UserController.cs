using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JARVIS.Models;
using JARVIS.Shared;
using static JARVIS.Models.Utilizador;

namespace JARVIS.Controllers
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
