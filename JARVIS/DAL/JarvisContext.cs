using JARVIS.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace JARVIS.DAL
{
    public class JarvisContext : DbContext
    {
        public JarvisContext() : base("JarvisContext")
        {
        }

        public DbSet<Alimento> Alimentos { set; get; }
        public DbSet<Receita> Receitas { set; get; }
        public DbSet<Utilizador> Utilizadores { set; get; }
        public DbSet<Avaliacao> Avaliacoes { set; get; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
