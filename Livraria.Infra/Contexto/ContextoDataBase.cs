using Livraria.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Infra.Contexto
{
    public class ContextoDataBase : DbContext
    {
        public ContextoDataBase(DbContextOptions<ContextoDataBase> options)
        : base(options)
        { }

        public DbSet<Livro> Livros { get; set; }
    }
}
