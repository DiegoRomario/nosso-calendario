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
        protected readonly NossoCalendarioContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(NossoCalendarioContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Insert(TEntity usuario)
        {
            _dbSet.Add(usuario);
        }

        public void Update(TEntity usuario)
        {
            _dbSet.Update(usuario);
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
