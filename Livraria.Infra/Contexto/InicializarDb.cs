using Livraria.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Livraria.Infra.Contexto
{
    public class InicializarDb
    {
        public static void Iniciar(ContextoDataBase contexto)
        {
            contexto.Database.EnsureCreated();

            var repositorioLivros = contexto.Set<Livro>();

            if (repositorioLivros.Any()) return;

            var livros = new[]
            {
                new Livro{Nome="Harry Potter", Quantidade=5, Autor = "J. K. Rowling", Editora = "Rocco", DataPublicacao = new DateTime(1997, 6, 26), QuantidadeMinimaCompra = 3},
                new Livro{Nome="Senhor dos Aneis", Quantidade=1, Autor = "J. R. R. Tolkien", QuantidadeMinimaCompra = 4},
                new Livro{Nome="Hércules", Quantidade=2},
            };

            foreach (var livro in livros)
            {
                repositorioLivros.Add(livro);
            }

            contexto.SaveChanges();
        }
    }
}
