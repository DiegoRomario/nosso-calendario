using NossoCalendario.Data.Context;
using NossoCalendario.Domain.Base;
using NossoCalendario.Domain.Entities;
using NossoCalendario.Domain.Interfaces;
using System.Threading.Tasks;

namespace NossoCalendario.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly NossoCalendarioContext _context;

        public UsuarioRepository(NossoCalendarioContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Insert(Usuario usuario)
        {
           _context.Add(usuario);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
