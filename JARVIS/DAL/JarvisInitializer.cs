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
                new Utilizador{Nome="Filipa",Data_nascimento=DateTime.Parse("1998-10-12"),Username="Mercy132",Password="pipoca",Email="welele@gmail.com",Foto=null,Admin=1},
                new Utilizador{Nome="Maria",Data_nascimento=DateTime.Parse("1998-03-29"),Username="niques",Password="wee",Email="flurry@gmail.com",Foto=null,Admin=1},
                new Utilizador{Nome="Chico",Data_nascimento=DateTime.Parse("1998-01-05"),Username="Cyborg",Password="lalala",Email="laurindinha@gmail.com",Foto=null,Admin=1},
                new Utilizador{Nome="Ines",Data_nascimento=DateTime.Parse("1998-11-02"),Username="sb_59",Password="bentinhas",Email="aaalves@gmail.com",Foto=null,Admin=1},
                new Utilizador{Nome="Pedro",Data_nascimento=DateTime.Parse("1998-10-02"),Username="sards90",Password="crica",Email="noobenta@gmail.com",Foto=null,Admin=1}
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