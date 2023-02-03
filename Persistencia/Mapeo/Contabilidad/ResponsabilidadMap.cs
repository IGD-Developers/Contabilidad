using Dominio.Contabilidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Mapeo.Contabilidad
{
    public class ResponsabilidadMap : IEntityTypeConfiguration<CntResponsabilidad>
    {
        public void Configure(EntityTypeBuilder<CntResponsabilidad> builder)
        {
            builder.ToTable("cnt_responsabilidad")
                .HasKey( pk => pk.Id);
            
        }
    }
}