using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JARVIS.Models;
using JARVIS.DataAccess;
using Microsoft.AspNetCore.Mvc.Rendering;
using static JARVIS.Models.Alimento;
using System.Text;
using System.Collections.ObjectModel;

namespace JARVIS.Controllers
{
    public class RecipeController : Controller
    {
        public ActionResult Index()
        {
            IConnection connection = new Connection();
            connection.Fetch();

            IDAO<Receita> rDAO = new ReceitaDAO(connection);

            Collection<Receita> rs = rDAO.ListAll();
            ModelState.Clear();
            
            return View(rs);
        }
        /*
        public ActionResult Index(int idReceita)
        {
            IConnection connection = new Connection();
            connection.Fetch();
            IDAO<Receita> rDAO = new ReceitaDAO(connection);

            return View(rDAO.FindById(Convert.ToString(idReceita)));
        }*/



        public ActionResult PreReceita(Alimento l)
        {
            return View(l);
        }

        public ActionResult Alternativa()
        {
            return View();
        }


    }
}
