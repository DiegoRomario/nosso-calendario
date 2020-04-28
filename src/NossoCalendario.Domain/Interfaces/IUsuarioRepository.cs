using NossoCalendario.Domain.Base;
using NossoCalendario.Domain.Entities;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NossoCalendario.Domain.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario> ValidarUsuario(string usuario, string senha);
        void InserirUsuario(Usuario usuario);
        void AlterarUsuario(Usuario usuario);
    }
}
