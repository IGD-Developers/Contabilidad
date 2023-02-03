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
            .HasKey(entity => entity.Id);

            builder.HasOne<CntExogenaFormato>(fc => fc.ExogenaFormato)
                .WithMany(ef=>ef.ExogenaFormatoFormatoColumnas)
                .HasForeignKey(fc => fc.IdExogenaformato);
        }
    }
}