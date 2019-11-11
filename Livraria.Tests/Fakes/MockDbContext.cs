using Livraria.Domain.Entidades;
using Livraria.Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;

namespace Livraria.Tests.Fakes
{
    public class MockDbContext<T>
    where T : Entidade
    {
        public static IDbContext Create() => Create(new List<T>());

        public static IDbContext Create(List<T> entities)
        {
            var queryable = entities.AsQueryable();
            var mockSet = Substitute.For<DbSet<T>, IQueryable<T>>();

            ((IQueryable<T>)mockSet).Provider.Returns(queryable.Provider);
            ((IQueryable<T>)mockSet).Expression.Returns(queryable.Expression);
            ((IQueryable<T>)mockSet).ElementType.Returns(queryable.ElementType);
            ((IQueryable<T>)mockSet).GetEnumerator().Returns(queryable.GetEnumerator());

            mockSet.When(set => set.Add(Arg.Any<T>())).Do(info => entities.Add(info.Arg<T>()));
            mockSet.When(set => set.Remove(Arg.Any<T>())).Do(info => entities.Remove(info.Arg<T>()));

            var dbContext = Substitute.For<IDbContext>();
            dbContext.Set<T>().Returns(mockSet);

            return dbContext;
        }
    }
}
