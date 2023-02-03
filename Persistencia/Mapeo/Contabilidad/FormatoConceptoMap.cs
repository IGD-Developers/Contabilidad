using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Contabilidad;

namespace Persistencia.Mapeo.Contabilidad
{
    public class FormatoConceptoMap : IEntityTypeConfiguration<CntFormatoConcepto>
    {
        public void Configure(EntityTypeBuilder<CntFormatoConcepto> builder)
        {
            builder
                .ToTable("cnt_formatoconcepto")
                .HasKey(entity => entity.Id);

            builder.HasOne<CntExogenaFormato>(fc => fc.ExogenaFormato)
                .WithMany(ef=>ef.ExogenaFormatoFormatoConceptos)
                .HasForeignKey(fc => fc.IdExogenaformato);

            builder.HasOne<CntExogenaConcepto>(fc => fc.ExogenaConcepto)
                .WithMany(ec=>ec.ExogenaConceptoFormatoConceptos)
                .HasForeignKey(fc => fc.IdExogenaconcepto);
        }
    }
}