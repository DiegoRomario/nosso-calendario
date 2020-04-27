using NossoCalendario.Domain.Base;
using NossoCalendario.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace NossoCalendario.Domain.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        void Insert(Usuario usuario);
        void Update(Usuario usuario);

    }
}
