using Livraria.Domain.Entidades;
using Livraria.Infra.ConfiguracaoEntity;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Infra.Contexto
{
    public class ContextoDataBase : DbContext
    {
        public ContextoDataBase(DbContextOptions<ContextoDataBase> options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LivroConfiguration());
        }

        public DbSet<Livro> Livros { get; set; }
    }
}
