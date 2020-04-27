using System;

namespace NossoCalendario.Domain.Base
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        IUnitOfWork UnitOfWork { get; }
    }

}
