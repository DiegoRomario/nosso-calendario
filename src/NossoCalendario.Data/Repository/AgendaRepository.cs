using Microsoft.EntityFrameworkCore;
using NossoCalendario.Data.Context;
using NossoCalendario.Domain.Entities;
using System.Threading.Tasks;

namespace NossoCalendario.Data.Repository
{
    public class AgendaRepository
    {
        protected readonly NossoCalendarioContext _context;
        protected readonly DbSet<Agenda> _dbSet;

        public AgendaRepository(NossoCalendarioContext context)
        {
            _context = context;
            _dbSet = context.Set<Agenda>();
        }

        public async Task Insert (Agenda agenda)
        {
            _dbSet.Add(agenda);
            await _context.SaveChangesAsync();
        }

    }
}
