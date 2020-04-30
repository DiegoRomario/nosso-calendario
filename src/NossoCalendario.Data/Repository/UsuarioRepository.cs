using NossoCalendario.Data.Base;
using NossoCalendario.Data.Context;
using NossoCalendario.Domain.Entities;
using NossoCalendario.Domain.Interfaces;
using System.Threading.Tasks;

namespace NossoCalendario.Data.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(NossoCalendarioContext context) : base(context)
        {
        }

        public Task InserirUsuario(Usuario usuario)
        {
            usuario.CriptografarSenha(PasswordEncryptorHelper.Hash(usuario.Senha));
            return base.Insert(usuario);
        }

    }
}
