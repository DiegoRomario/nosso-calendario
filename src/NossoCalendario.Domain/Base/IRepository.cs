using System;
using System.Threading.Tasks;

namespace NossoCalendario.Domain.Base
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        IUnitOfWork UnitOfWork { get; }
        Task Insert(TEntity entity);
    }

}
