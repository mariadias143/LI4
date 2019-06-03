using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JARVIS.Models;
using JARVIS.DataAccess;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.ObjectModel;
using System.Text;

namespace JARVIS.Controllers
{
    public class RecipeController : Controller
    {
        public ActionResult Index()
        {
            IConnection connection = new Connection();
            connection.Fetch();

            IDAO<Receita> rDAO = new ReceitaDAO(connection);

            Collection<Receita> r = rDAO.ListAll();
            ModelState.Clear();

            return View(r);
        }

        [HttpGet]
        public ActionResult Ingredients(int id)
        {
            IConnection connection = new Connection();
            connection.Fetch();
            IDAO<Receita> rDAO = new ReceitaDAO(connection);
            Collection<Receita> rs = rDAO.ListAll();
            Receita r = rs.ElementAt(id - 1);

            return View(r);
        }

        [HttpPost]
        public ActionResult Ingredients(int idReceita, Receita Obj)
        {
            StringBuilder sb = new StringBuilder();
            List<Alimento> nao_selecionados = new List<Alimento>();
            List<Alimento> alternativas = new List<Alimento>();
            Alimento alimento = new Alimento();
            Alimento alternativo = new Alimento();


            foreach (Alimento item in Obj.Ingredientes)
            {

                if (item.IsChecked)
                {
                }
                else
                {
                    IConnection connection = new Connection();
                    connection.Fetch();
                    IDAO<Alimento> aDAO = new AlimentoDAO(connection);
                    alimento = aDAO.FindByName(item.Nome);

                    sb.Append(item.Nome + "; ");

                    if (alimento.temAlternativa())
                    {
                        connection = new Connection();
                        connection.Fetch();
                        aDAO = new AlimentoDAO(connection);
                        alternativo = aDAO.FindById(alimento.alternativo);
                        alternativas.Add(alternativo);
                    }
                    nao_selecionados.Add(alimento);
                    ViewBag.alimento = alimento.idAlimento;
                }

            }
            ViewBag.Loc = "The following items were not checked: " + sb.ToString() + "\nDo you wish to replace them for a similar alternative?";
            ViewBag.data = nao_selecionados;
            ViewBag.alternativa = alternativas;
            if (nao_selecionados.Count > 0)
            {
                return View("Alternativa");
            }


            else return View("Alternativa");
        }



       
        public ActionResult Alternativa()
       {
            return View();
        }
      /*  public ActionResult Execute(int idReceita,int passo)
        {
            Passo p;
            IConnection connection = new Connection();
            connection.Fetch();
            IDAO<Receita> rDAO = new ReceitaDAO(connection);
            Receita r = rDAO.FindById(idReceita);
            int num_passos = r.Passos.Count();
            if (passo < 0) {  p = r.Passos[0]; return View(p); }
            if (passo == num_passos) {return View("Evaluation",r);}
             p = r.Passos[passo];
            return View(p);   
        }
        */
        public ActionResult Evaluation()
        {
            return View();
        }

      


        private IList<SelectListItem> GetFoods()
        {
            return new List<SelectListItem>
            {
                new SelectListItem {Text = "Apple", Value = "Apple"},
                new SelectListItem {Text = "Pear", Value = "Pear"},
                new SelectListItem {Text = "Banana", Value = "Banana"},
                new SelectListItem {Text = "Orange", Value = "Orange"},
            };
        }
    }
}
