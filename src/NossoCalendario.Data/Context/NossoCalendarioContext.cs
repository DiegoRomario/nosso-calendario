using Microsoft.EntityFrameworkCore;
using NossoCalendario.Domain.Base;
using NossoCalendario.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NossoCalendario.Data.Context
{
    public class NossoCalendarioContext : DbContext, IUnitOfWork
    {
        public NossoCalendarioContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            HandleFieldType(modelBuilder, "VARCHAR(100)", typeof(string));
            HandleFieldType(modelBuilder, "DATETIME", typeof(DateTime));
            HandleFieldType(modelBuilder, "DATETIME", typeof(Nullable<DateTime>));
            HandleFieldType(modelBuilder, "DECIMAL(12,2)", typeof(decimal));

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NossoCalendarioContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

        private static void HandleFieldType(ModelBuilder modelBuilder, string sqlFieldType, Type type)
        {
            foreach (var property in modelBuilder
                  .Model
                  .GetEntityTypes()
                  .SelectMany(
                     e => e.GetProperties()
                        .Where(p => p.ClrType == type)))
            {
                property.SetColumnType(sqlFieldType);
            }
        }

        public async Task<bool> Commit()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("IncluidoEm") != null && entry.Entity.GetType().GetProperty("AlteradoEm") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("IncluidoEm").CurrentValue = DateTime.Now;
                    entry.Property("AlteradoEm").IsModified = false;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("IncluidoEm").IsModified = false;
                    entry.Property("AlteradoEm").CurrentValue = DateTime.Now;
                }
            }

            return await base.SaveChangesAsync() > 0;
        }
    }
}
