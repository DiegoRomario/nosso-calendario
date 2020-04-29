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
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
