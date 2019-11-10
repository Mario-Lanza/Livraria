using Livraria.Domain.Entidades;
using Livraria.Domain.Interfaces.Repositorios;
using Livraria.Domain.Interfaces.Servicos;
using System.Collections.Generic;

namespace Livraria.Domain.Services
{
    public class ServicoLivros : ServicoBase<Livro>, IServicoLivros
    {
        private readonly IRepositorioLivros repositorioLivros;

        public ServicoLivros(IRepositorioLivros repositorioLivros)
            : base(repositorioLivros)
        {
            this.repositorioLivros = repositorioLivros;
        }

        public IEnumerable<Livro> ObterLivrosComEstoqueAbaixoDoMinimoDesejado()
        {
            return repositorioLivros.ObterLivrosComEstoqueAbaixoDoMinimoDesejado();
        }

        public IEnumerable<Livro> ObterLivrosPorOrdemAlfabetica()
        {
            return repositorioLivros.ObterLivrosPorOrdemAlfabetica();
        }
    }
}
