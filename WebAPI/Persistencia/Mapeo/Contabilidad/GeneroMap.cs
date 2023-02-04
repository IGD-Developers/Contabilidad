using ContabilidadWebAPI.Dominio.Contabilidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContabilidadWebAPI.Persistencia.Mapeo.Contabilidad;

public class GeneroMap : IEntityTypeConfiguration<CntGenero>
{
    public void Configure(EntityTypeBuilder<CntGenero> builder)
    {
        builder.ToTable("cnt_genero")
            .HasKey(pk => pk.Id);

    }
}