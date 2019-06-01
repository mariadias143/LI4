using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JARVIS.Models;
using JARVIS.DataAccess;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JARVIS.Controllers
{
    public class RecipeController : Controller
    {
        public ActionResult Index()
        {
            var model = new Receita
            {
                AvailableFoods = GetFoods()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(Receita model)
        {
            IConnection connection = new Connection();
            connection.Fetch();
            IDAO<Receita> rDAO = new ReceitaDAO(connection);
            List<Alimento> lista_ingredientes = model.Ingredientes;
            List<Alimento> lista_final = new List<Alimento>();

            if (ModelState.IsValid)
            {
                IList<string> selecionados = model.SelectedFoods;

                foreach (Alimento a in lista_ingredientes)
                {
                    bool disponivel = false;
                    foreach (string s in selecionados)
                    {
                        if (a.Nome.Equals(s))
                        {
                            disponivel = true;
                            lista_final.Add(a);
                        }
                    }
                    if (!disponivel)
                    {
                        Alimento alt;
                        if (a.temAlternativa())
                        {
                            alt = a.alternativa();
                            lista_final.Add(alt);
                        }
                    }
                }
                model.executaReceita(lista_final);

                return RedirectToAction("Success");
            }
            model.AvailableFoods = GetFoods();
            return View(model);
        }

        public ActionResult Success()
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
