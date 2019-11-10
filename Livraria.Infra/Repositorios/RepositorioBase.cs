using Livraria.Domain.Entidades;
using Livraria.Domain.Interfaces.Repositorios;
using Livraria.Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Livraria.Domain.Repositorios
{
    public class RepositorioBase<TEntidade> : IRepositorioBase<TEntidade> where TEntidade : Entidade
    {
        private readonly ContextoDataBase db;
        private readonly DbSet<TEntidade> setBase;

        public RepositorioBase(ContextoDataBase contexto)
        {
            db = contexto;
            setBase = contexto.Set<TEntidade>();
        }
        public void Alterar(TEntidade entidade)
        {
            db.Entry(entidade).State = EntityState.Modified;
            Save();
        }

        public TEntidade Consultar(Guid id)
        {
            return setBase.Find(id);
        }

        public void Excluir(TEntidade entidade)
        {
            setBase.Remove(entidade);
            Save();
        }

        public void Excluir(Guid id)
        {
            var entidade = Consultar(id);
            setBase.Remove(entidade);
            Save();
        }

        public IQueryable<TEntidade> RetornarTodos()
        {
            return setBase;
        }

        public void Salvar(TEntidade entidade)
        {
            setBase.Add(entidade);
            Save();
        }

        private void Save()
        {
            db.SaveChanges();
        }
    }
}
