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
        public RepositorioLivros(ContextoDataBase context): base(context){}
        public IEnumerable<Livro> ObterLivrosPorOrdemAlfabetica()
        {
            var teste =  RetornarTodos().OrderBy(livro => livro.Nome).ToList();
            return teste;
        }

        public IEnumerable<Livro> ObterLivrosComEstoqueAbaixoDoMinimoDesejado()
        {
            return RetornarTodos().Where(livro => livro.QuantidadeMenorDoLimiteMinimo()).ToList();
        }
    }
}
