using Livraria.Domain.Entidades;
using System.Linq;

namespace Livraria.Domain.Interfaces.Servicos
{
    public interface IServicoBase<TEntidade> where TEntidade : Entidade
    {
        void Salvar(TEntidade entidade);
        TEntidade Consultar(int id);
        IQueryable<TEntidade> RetornarTodos();
        void Alterar(TEntidade entidade);
        void Excluir(TEntidade entidade);
    }
}
