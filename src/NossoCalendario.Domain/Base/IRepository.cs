using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NossoCalendario.Domain.Base
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        IUnitOfWork UnitOfWork { get; }
        Task<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate);
    }

}
