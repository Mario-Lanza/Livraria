using Livraria.Domain.Entidades;
using System;
using System.Linq;

namespace Livraria.Domain.Interfaces.Servicos
{
    public interface IServicoBase<TEntidade> where TEntidade : Entidade
    {
        void Salvar(TEntidade entidade);
        TEntidade Consultar(Guid id);
        IQueryable<TEntidade> RetornarTodos();
        void Alterar(TEntidade entidade);
        void Excluir(TEntidade entidade);
        void Excluir(Guid id);
    }
}
