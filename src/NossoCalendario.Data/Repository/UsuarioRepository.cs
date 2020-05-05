using Microsoft.EntityFrameworkCore;
using NossoCalendario.Data.Context;
using NossoCalendario.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace NossoCalendario.Data.Repository
{
    public class UsuarioRepository
    {
        protected readonly NossoCalendarioContext _context;
        protected readonly DbSet<Usuario> _dbSet;

        public UsuarioRepository(NossoCalendarioContext context)
        {
            _context = context;
            _dbSet = context.Set<Usuario>();
        }

        public async Task Insert(Usuario usuario)
        {
            _dbSet.Add(usuario);
            await _context.SaveChangesAsync();
        }

    }
}
