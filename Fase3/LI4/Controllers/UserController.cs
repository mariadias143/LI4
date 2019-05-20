using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LI4.Models;

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

        public IActionResult About(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilizador utilizador = db.Utilizador.Find(id);
            if (utilizador == null)
            {
                return HttpNotFound();
            }
            return View(utilizador);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateModel model)
        {
            if (ModelState.IsValid)
            {
                Utilizador utilizador = new Utilizador();
                utilizador.Email = model.Email;
                utilizador.Nome = model.Nome;
                utilizador.Password = model.Password;
                utilizador.Username = model.Username;
                utilizador.Admin = 1;
                db.Utilizador.Add(utilizador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }


    }
}
