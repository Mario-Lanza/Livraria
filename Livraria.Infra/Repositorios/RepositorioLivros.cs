using Livraria.Domain.Repositorios;
using Livraria.Domain.Entidades;
using Livraria.Domain.Interfaces.Repositorios;
using Livraria.Infra.Contexto;
using System.Collections.Generic;
using System.Linq;

namespace Livraria.Infra.Repositorios
{
    public class RepositorioLivros : RepositorioBase<Livro>, IRepositorioLivros
    {
        public RepositorioLivros(IDbContext context): base(context){}
        public IEnumerable<Livro> ObterLivrosPorOrdemAlfabetica()
        {
            return RetornarTodos().OrderBy(livro => livro.Nome).ToList();
        }

        public IEnumerable<Livro> ObterLivrosComEstoqueAbaixoDoMinimoDesejado()
        {
            return RetornarTodos()
                .Where(livro => livro.QuantidadeMinimaCompra != null && livro.Quantidade < livro.QuantidadeMinimaCompra)
                .ToList();
        }
    }
}
