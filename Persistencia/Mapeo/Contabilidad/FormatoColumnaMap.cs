using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Contabilidad;

namespace Persistencia.Mapeo.Contabilidad
{
    public class FormatoColumnaMap : IEntityTypeConfiguration<CntFormatoColumna>
    {
        public void Configure(EntityTypeBuilder<CntFormatoColumna> builder)
        {
            builder
            .ToTable("cnt_formatocolumna")  
            .HasKey(entity => entity.id);

            builder.HasOne<CntExogenaFormato>(fc => fc.exogenaFormato)
                .WithMany(ef=>ef.exogenaFormatoFormatoColumnas)
                .HasForeignKey(fc => fc.id_exogenaformato);
        }
    }
}