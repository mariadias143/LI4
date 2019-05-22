using JARVIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JARVIS.DAL
{
    public class JarvisInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<JarvisContext>
    {
        protected override void Seed(JarvisContext context)
        {
            var users = new List<Utilizador>
            {
                new Utilizador{nome="Filipa",data_nascimento=DateTime.Parse("1998-10-12"),username="Mercy132",password="pipoca",email="welele@gmail.com",foto=null,admin=1},
                new Utilizador{nome="Maria",data_nascimento=DateTime.Parse("1998-03-29"),username="niques",password="wee",email="flurry@gmail.com",foto=null,admin=1},
                new Utilizador{nome="Chico",data_nascimento=DateTime.Parse("1998-01-05"),username="Cyborg",password="lalala",email="laurindinha@gmail.com",foto=null,admin=1},
                new Utilizador{nome="Ines",data_nascimento=DateTime.Parse("1998-11-02"),username="sb_59",password="bentinhas",email="aaalves@gmail.com",foto=null,admin=1},
                new Utilizador{nome="Pedro",data_nascimento=DateTime.Parse("1998-10-02"),username="sards90",password="crica",email="noobenta@gmail.com",foto=null,admin=1}
            };
            users.ForEach(s => context.Utilizadores.Add(s));
            context.SaveChanges();

            var avals = new List<Avaliacao>
            {
                new Avaliacao{IdUtilizador=1,Classificacao=3},
                new Avaliacao{IdUtilizador=2,Classificacao=2},
                new Avaliacao{IdUtilizador=3,Classificacao=5},
                new Avaliacao{IdUtilizador=3,Classificacao=4},
            };
            avals.ForEach(s => context.Avaliacoes.Add(s));
            context.SaveChanges();
        }
    }
}