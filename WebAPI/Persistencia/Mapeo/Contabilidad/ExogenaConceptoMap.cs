using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ContabilidadWebAPI.Dominio.Contabilidad;

namespace ContabilidadWebAPI.Persistencia.Mapeo.Contabilidad;

public class ExogenaConceptoMap : IEntityTypeConfiguration<CntExogenaConcepto>
{
    public void Configure(EntityTypeBuilder<CntExogenaConcepto> builder)
    {
        builder
            .ToTable("cnt_exogenaconcepto")
            .HasKey(entity => entity.Id);
    }
}