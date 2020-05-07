using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NossoCalendario.Domain.Entities;


namespace NossoCalendario.Data.Mapping
{
    public class AgendaMapping : IEntityTypeConfiguration<Agenda>
    {
        public void Configure(EntityTypeBuilder<Agenda> builder)
        {
            builder.ToTable("Agenda").HasKey("Id");
            builder.Property("Nome").IsRequired().HasColumnType("VARCHAR(50)");
            builder.Property("Descricao").IsRequired().HasColumnType("VARCHAR(250)");
            builder.Property(a => a.UsuarioId).IsRequired();
        }
    }
}
