using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JARVIS.Models;
using JARVIS.DataAccess;

namespace JARVIS.Controllers
{
    public class UserController : Controller
    {
        // 1. *************RETRIEVE ALL User DETAILS ******************
        // GET: User
        public ActionResult Index()
        {
            IConnection connection = new Connection();
            connection.Fetch();

            IDAO<Utilizador> uDAO = new UtilizadorDAO(connection);

            ModelState.Clear();
            return View(uDAO.FindById(1));
        }

        // 2. *************ADD NEW User ******************
        // GET: User/Create
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Utilizador smodel)
        {
            IConnection connection = new Connection();
            connection.Fetch();

            try
            {
                if (ModelState.IsValid)
                {
                    IDAO<Utilizador> uDAO = new UtilizadorDAO(connection);
                    Utilizador u = new Utilizador();


                    uDAO.Insert(smodel);

                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                string message = e.Message; // or using e.InnerException.Message
                Console.WriteLine("{0} Exception caught.", e);
            }
            return View();
        }



        // 3. ************* EDIT User DETAILS ******************
        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            IConnection connection = new Connection();
            connection.Fetch();
            IDAO<Utilizador> uDAO = new UtilizadorDAO(connection);

            return View(uDAO.FindById(1));
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Utilizador smodel)
        {
            try
            {
                IConnection connection = new Connection();
                connection.Fetch();
                IDAO<Utilizador> uDAO = new UtilizadorDAO(connection);
                uDAO.Update(Convert.ToString(id), smodel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // 4. ************* DELETE User DETAILS ******************
        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                IConnection connection = new Connection();
                connection.Fetch();
                IDAO<Utilizador> uDAO = new UtilizadorDAO(connection);
                if (uDAO.remove(Convert.ToString(id)))
                {
                    ViewBag.AlertMsg = "User Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
