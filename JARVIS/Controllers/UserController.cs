using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JARVIS.Models;
using JARVIS.DataAccess;
using System.IO;

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
            return View(uDAO.ListAll());
        }

        // 2. *************ADD NEW User ******************
        // GET: User/Create
        public ActionResult Register()
        {
            Utilizador u = new Utilizador();
            return View(u);
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

                    Utilizador u = new Utilizador();
                    IDAO<Utilizador> uDAO = new UtilizadorDAO(connection);
                    byte[] fot = ImageToBinary(smodel.ImageUpload);


                    smodel.Foto = fot;
                    uDAO.Insert(smodel);

                    return RedirectToAction("Index");

                }
                return View();
            }
            catch (Exception e)
            {
                string message = e.Message; // or using e.InnerException.Message
                Console.WriteLine("{0} Exception caught.", e);
            }
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
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
        public static byte[] ImageToBinary(string imagePath)
        {
            FileStream fS = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
            byte[] b = new byte[fS.Length];
            fS.Read(b, 0, (int)fS.Length);
            fS.Close();
            return b;
        }
    }
}
