using NossoCalendario.Domain.Base;
using NossoCalendario.Domain.Entities;

namespace NossoCalendario.Domain.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        void InserirUsuario(Usuario usuario);
    }
}
