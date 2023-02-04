using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ContabilidadWebAPI.Dominio.Contabilidad;

namespace ContabilidadWebAPI.Persistencia.Mapeo.Contabilidad;

public class EntidadMap : IEntityTypeConfiguration<CntEntidad>
{
    public void Configure(EntityTypeBuilder<CntEntidad> builder)
    {
        builder
            .ToTable("cnt_entidad")
            .HasKey(entity => entity.Id);

        builder
            .HasOne(e => e.Tercero)
            .WithMany(t => t.EntidadTerceros)
            .HasForeignKey(e => e.IdTercero);

        builder
            .HasOne(e => e.TipoImpuesto)
            .WithMany(ti => ti.TipoImpuestoEntidades)
            .HasForeignKey(e => e.IdTipoimpuesto);
    }
}