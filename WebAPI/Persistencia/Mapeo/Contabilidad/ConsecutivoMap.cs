using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ContabilidadWebAPI.Dominio.Contabilidad;

namespace ContabilidadWebAPI.Persistencia.Mapeo.Contabilidad;

public class ConsecutivoMap : IEntityTypeConfiguration<CntConsecutivo>
{
    public void Configure(EntityTypeBuilder<CntConsecutivo> builder)
    {
        builder
            .ToTable("cnt_consecutivo")
            .HasKey(entity => entity.Id);

        builder
            .HasOne(cs => cs.TipoComprobante)
            .WithMany(tc => tc.TipoComprobanteConsecutivos)
            .HasForeignKey(cs => cs.IdTipocomprobante);

        builder
            .HasOne(cs => cs.Sucursal)
            .WithMany(tc => tc.SucursalConsecutivo)
            .HasForeignKey(cs => cs.IdSucursal);
    }
}