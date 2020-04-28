using Microsoft.EntityFrameworkCore;
using NossoCalendario.Data.Context;
using NossoCalendario.Domain.Base;
using NossoCalendario.Domain.Entities;
using NossoCalendario.Domain.Interfaces;

namespace NossoCalendario.Data.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(NossoCalendarioContext context) : base(context)
        {
        }
    }
}
