using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ContabilidadWebAPI.Dominio.Contabilidad;

namespace ContabilidadWebAPI.Persistencia.Mapeo.Contabilidad;

public class FormatoConceptoMap : IEntityTypeConfiguration<CntFormatoConcepto>
{
    public void Configure(EntityTypeBuilder<CntFormatoConcepto> builder)
    {
        builder
            .ToTable("cnt_formatoconcepto")
            .HasKey(entity => entity.Id);

        builder.HasOne(fc => fc.ExogenaFormato)
            .WithMany(ef => ef.ExogenaFormatoFormatoConceptos)
            .HasForeignKey(fc => fc.IdExogenaformato);

        builder.HasOne(fc => fc.ExogenaConcepto)
            .WithMany(ec => ec.ExogenaConceptoFormatoConceptos)
            .HasForeignKey(fc => fc.IdExogenaconcepto);
    }
}