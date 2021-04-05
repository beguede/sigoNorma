using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NormasService.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace NormasService.Infrastructure.Database.Mapping
{
    [ExcludeFromCodeCoverage]
    public class NormaDbMap : IEntityTypeConfiguration<Norma>
    {
        public void Configure(EntityTypeBuilder<Norma> builder)
        {
            builder.ToTable("NORMAS");

            builder.HasKey(c => c.Id)
                .HasName("PK_NORMAS");

            builder.Property(c => c.Id)
                .IsRequired()
                .HasColumnName("ID");

            builder.Property(c => c.Codigo)
                .HasColumnName("CODIGO");

            builder.Property(c => c.DataPublicacao)
                .HasColumnName("DATAPUBLICACAO");

            builder.Property(c => c.Titulo)
                .HasColumnName("TITULO");

            builder.Property(c => c.Comite)
                .HasColumnName("COMITE");

            builder.Property(c => c.Status)
                .HasColumnName("STATUS");

            builder.Property(c => c.Idioma)
                .HasColumnName("IDIOMA");

            builder.Property(c => c.Organismo)
                .HasColumnName("ORGANISMO");

            builder.Property(c => c.Objetivo)
                .HasColumnName("OBJETIVO");
        }
    }
}
