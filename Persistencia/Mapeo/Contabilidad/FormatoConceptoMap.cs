using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Contabilidad;

namespace Persistencia.Mapeo.Contabilidad;

public class FormatoConceptoMap : IEntityTypeConfiguration<CntFormatoConcepto>
{
    public void Configure(EntityTypeBuilder<CntFormatoConcepto> builder)
    {
        builder
            .ToTable("cnt_formatoconcepto")
            .HasKey(entity => entity.id);

        builder.HasOne<CntExogenaFormato>(fc => fc.exogenaFormato)
            .WithMany(ef=>ef.exogenaFormatoFormatoConceptos)
            .HasForeignKey(fc => fc.id_exogenaformato);

        builder.HasOne<CntExogenaConcepto>(fc => fc.exogenaConcepto)
            .WithMany(ec=>ec.exogenaConceptoFormatoConceptos)
            .HasForeignKey(fc => fc.id_exogenaconcepto);
    }
}