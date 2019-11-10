using Livraria.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Domain.Interfaces.Servicos
{
    public interface IServicoLivros : IServicoBase<Livro>
    {
        IEnumerable<Livro> ObterLivrosPorOrdemAlfabetica();
        IEnumerable<Livro> ObterLivrosComEstoqueAbaixoDoMinimoDesejado();
    }
}
