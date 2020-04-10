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
            List<Alimento> original = new List<Alimento>();
            List<Alimento> indispensaveis = new List<Alimento>();
            Alimento alimento = new Alimento();
            Alimento alternativo = new Alimento();
            bool naopodecontinuar = false;

            string path_and_query = HttpContext.Request.Path;
            char last = path_and_query[path_and_query.Length - 1];
            int id = last - '0';

            IConnection connection = new Connection();
            connection.Fetch();
            IDAO<Receita> rDAO = new ReceitaDAO(connection);
            Receita rs = rDAO.FindById(id);

            foreach (Alimento item in Obj.Ingredientes)
            {


                if (!item.IsChecked)
                {
                    connection = new Connection();
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
                        original.Add(alimento);
                    }
                    nao_selecionados.Add(alimento);
                    ViewBag.alimento = alimento.idAlimento;

                    foreach (int i in rs.indispensaveis)
                    {
                        if (i == alimento.idAlimento)
                            naopodecontinuar = true;
                    }

                }
            }


            ViewBag.data = nao_selecionados;
            ViewBag.alternativa = alternativas;
            ViewBag.indispensaveis = indispensaveis;
            ViewBag.original = original;


            if (naopodecontinuar)
            {
                ViewBag.condicional = "Não é possível continuar com os ingredientes selecionados";
                return View(rs);
            }

            foreach (Alimento a in nao_selecionados)
            {
                if (a.alternativo > 0)
                {
                    ViewBag.Loc = "The following items were not checked: " + sb.ToString() + "\r\nDo you wish to replace them for a similar alternative?";
                }
                return View("Alternativa");
            }

            return View("Execute",rs.Passos[0]);
        }


        public ActionResult Alternativa()
       {
            return View();
        }
         public ActionResult Execute(int idReceita,int passo)
          {
            Avaliacao av=new Avaliacao();
              Passo p;
              IConnection connection = new Connection();
              connection.Fetch();
              IDAO<Receita> rDAO = new ReceitaDAO(connection);
              Receita r = rDAO.FindById(idReceita);
              int num_passos = r.Passos.Count;

            Console.WriteLine("ssssssss"+num_passos);
              if (passo < 0) {  p = r.Passos[0]; return View(p); }
              if (passo == num_passos) {
                av.idReceita = idReceita;
              return View("Evaluation",av);
              }
            else
            {
                p = r.Passos[passo];
                return View(p);
            }
          }
          

        public ActionResult Evaluation(Avaliacao av)
        {
            IConnection connection = new Connection();
            connection.Fetch();
            int receita = av.idReceita;
            string avaliacao = av.SelectedAnswer;
            if (avaliacao.Equals("Answer1"))
            {

                av.idUtilizador = 1;
                av.Classificacao = 1;
                IDAO<Avaliacao> aDAO = new AvaliacaoDAO(connection);
                aDAO.Insert(av);
            }
            if (avaliacao.Equals("Answer2"))
            {

                av.idUtilizador = 1;
                av.Classificacao = 2;
                IDAO<Avaliacao> aDAO = new AvaliacaoDAO(connection);
                aDAO.Insert(av);
            }
            if (avaliacao.Equals("Answer3"))
            {
               
                av.idUtilizador = 1;
                av.Classificacao = 3;
                IDAO<Avaliacao> aDAO = new AvaliacaoDAO(connection);
                aDAO.Insert(av);
            }
            if (avaliacao.Equals("Answer4"))
            {
              
                av.idUtilizador = 1;
                av.Classificacao = 4;
                IDAO<Avaliacao> aDAO = new AvaliacaoDAO(connection);
                aDAO.Insert(av);
            }
            if (avaliacao.Equals("Answer5"))
            {

                av.idUtilizador = 1;
                av.Classificacao = 5;
                IDAO<Avaliacao> aDAO = new AvaliacaoDAO(connection);
                aDAO.Insert(av);
            }

            IDAO<Receita> rDAO = new ReceitaDAO(connection);
            //  Receita r = rDAO.FindById(1);
            return RedirectToPage("~/Home/Index");
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
