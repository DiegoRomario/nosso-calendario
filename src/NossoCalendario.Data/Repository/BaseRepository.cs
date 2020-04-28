using Microsoft.EntityFrameworkCore;
using NossoCalendario.Data.Context;
using NossoCalendario.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NossoCalendario.Data.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly NossoCalendarioContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(NossoCalendarioContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task Insert(TEntity usuario)
        {
            await _context.AddAsync(usuario);
        }

        public async Task Update(TEntity usuario)
        {
            await Task.FromResult(_context.Update(usuario));
        }
        public async Task<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).FirstOrDefaultAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
