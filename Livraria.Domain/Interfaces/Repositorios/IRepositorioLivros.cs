using Livraria.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Interfaces.Repositorios
{
    public interface IRepositorioLivros : IRepositorioBase<Livro>
    {
        public IEnumerable<Livro> ObterLivrosPorOrdemAlfabetica();
        IEnumerable<Livro> ObterLivrosComEstoqueAbaixoDoMinimoDesejado();
    }
}
