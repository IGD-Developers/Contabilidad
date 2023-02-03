using Dominio.Contabilidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Mapeo.Contabilidad;

public class ResponsabilidadTerMap : IEntityTypeConfiguration<CntResponsabilidadTer>
{
    public void Configure(EntityTypeBuilder<CntResponsabilidadTer> builder)
    {
        builder.ToTable("cnt_responsabilidad_ter")
            .HasKey(pk => pk.Id);

        builder.HasOne<CntTercero>(rter => rter.Tercero)
            .WithMany(ter => ter.ResponsabilidadTerceros)
            .HasForeignKey(rter => rter.IdTercero);
            
        builder.HasOne<CntResponsabilidad>(rter => rter.Responsabilidad)
            .WithMany(res => res.ReponsabilidadResponsabilidadTerceros)
            .HasForeignKey(rter => rter.IdResponsabilidad);
        
    }
}