using Dominio.Contabilidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Mapeo.Contabilidad
{
    public class RegimenMap : IEntityTypeConfiguration<CntRegimen>
    {
        public void Configure(EntityTypeBuilder<CntRegimen> builder)
        {
            builder.ToTable("cnt_regimen")
                .HasKey( pk => pk.id);
            
        }
    }
}