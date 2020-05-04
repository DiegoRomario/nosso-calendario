using Microsoft.EntityFrameworkCore;
using NossoCalendario.Domain.Entities;
using System;
using System.Linq;

namespace NossoCalendario.Data.Context
{
    public class NossoCalendarioContext : DbContext
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

    }
}
