using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ContabilidadWebAPI.Dominio.Contabilidad;

namespace ContabilidadWebAPI.Persistencia.Mapeo.Contabilidad;

public class BancoMap : IEntityTypeConfiguration<CntBanco>
{
    public void Configure(EntityTypeBuilder<CntBanco> builder)
    {
        builder
            .ToTable("cnt_banco")
            .HasKey(entity => entity.Id);
    }
}