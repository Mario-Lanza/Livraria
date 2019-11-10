using Livraria.Domain.Entidades;
using System.Linq;

namespace Livraria.Domain.Interfaces.Repositorios
{
    public interface IRepositorioBase<TEntidade> where TEntidade : Entidade
    {
        void Salvar(TEntidade entidade);
        TEntidade Consultar(int id);
        IQueryable<TEntidade> RetornarTodos();
        void Alterar(TEntidade entidade);
        void Excluir(TEntidade entidade);
    }
}
