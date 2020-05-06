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

        public Task<Agenda> Insert (Agenda agenda)
        {
            _dbSet.Add(agenda);
            return Task.FromResult(agenda);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
