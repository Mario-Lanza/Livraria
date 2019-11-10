using System.Linq;
using Livraria.Domain.Entidades;
using Livraria.Domain.Interfaces.Repositorios;
using Livraria.Domain.Interfaces.Servicos;

namespace Livraria.Domain.Services
{
    public class ServicoBase<TEntidade> : IServicoBase<TEntidade> where TEntidade : Entidade
    {
        private readonly IRepositorioBase<TEntidade> repositorio;

        public ServicoBase(IRepositorioBase<TEntidade> repositorio)
        {
            this.repositorio = repositorio;
        }

        public void Alterar(TEntidade entidade)
        {
            repositorio.Alterar(entidade);
        }

        public TEntidade Consultar(int id)
        {
            return repositorio.Consultar(id);
        }

        public void Excluir(TEntidade entidade)
        {
            repositorio.Excluir(entidade);
        }

        public IQueryable<TEntidade> RetornarTodos()
        {
            return repositorio.RetornarTodos();
        }

        public void Salvar(TEntidade entidade)
        {
            repositorio.Salvar(entidade);
        }
    }
}
