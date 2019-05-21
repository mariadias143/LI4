using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JARVIS.Models;
using static JARVIS.Models.Utilizador;
using JARVIS.Shared;

namespace JARVIS.Controllers
{
    [Route("[controller]/[action]")]
    public class UserViewController : Controller
    {
        private UserHandling userHandling;

        public UserViewController(UserContext context)
        {
            userHandling = new UserHandling(context);
        }

        public IActionResult getUsers()
        {  
            Utilizador[] users = userHandling.getUsers();
            return View(users);
        }

        [HttpGet]
        public IActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterUser([Bind] Utilizador user)
        {
            if (ModelState.IsValid)
            {
                bool RegistrationStatus = this.userHandling.RegisterUser(user);
                if (RegistrationStatus)
                {
                    ModelState.Clear();
                    TempData["Success"] = "Registration Successful!";
                }
                else
                {
                    TempData["Fail"] = "This User ID already exists. Registration Failed.";
                }
            }
            return View();
        }
    }
}
