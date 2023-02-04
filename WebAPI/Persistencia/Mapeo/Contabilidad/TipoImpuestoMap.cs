using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ContabilidadWebAPI.Dominio.Contabilidad;

namespace ContabilidadWebAPI.Persistencia.Mapeo.Contabilidad;

public class TipoImpuestoMap : IEntityTypeConfiguration<CntTipoImpuesto>
{
    public void Configure(EntityTypeBuilder<CntTipoImpuesto> builder)
    {
        builder
            .ToTable("cnt_tipoimpuesto")
            .HasKey(entity => entity.Id);
    }
}