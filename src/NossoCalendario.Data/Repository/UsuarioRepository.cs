using Microsoft.EntityFrameworkCore;
using NossoCalendario.Data.Base;
using NossoCalendario.Data.Context;
using NossoCalendario.Domain.Base;
using NossoCalendario.Domain.Entities;
using NossoCalendario.Domain.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace NossoCalendario.Data.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(NossoCalendarioContext context) : base(context)
        {
        }

        public void AlterarUsuario(Usuario usuario)
        {
            usuario.CriptografarSenha(PasswordEncryptorHelper.Hash(usuario.Senha));
            base.Update(usuario);

        }

        public void InserirUsuario(Usuario usuario)
        {
            usuario.CriptografarSenha(PasswordEncryptorHelper.Hash(usuario.Senha));
            base.Insert(usuario);
        }

        public async Task<Usuario> ValidarUsuario(string usuario, string senha)
        {
            Usuario user = await base.GetBy(u => u.Email == usuario);
            if (user == null || !PasswordEncryptorHelper.Verify(senha, user.Senha))
                user = null;

            return user;

        }
    }
}
