using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NossoCalendario.Domain.Entities;


namespace NossoCalendario.Data.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario").HasKey("Id");
            builder.Property("Nome").HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property("Email").HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property("Senha").HasColumnType("VARCHAR(240)").IsRequired();
            builder.HasAlternateKey(a => a.Email);
        }
    }
}
