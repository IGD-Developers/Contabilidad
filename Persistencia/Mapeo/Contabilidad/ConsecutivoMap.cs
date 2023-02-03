using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Contabilidad;

namespace Persistencia.Mapeo.Contabilidad;

public class ConsecutivoMap : IEntityTypeConfiguration<CntConsecutivo>
{
    public void Configure(EntityTypeBuilder<CntConsecutivo> builder)
    {
        builder
            .ToTable("cnt_consecutivo")
            .HasKey(entity => entity.id);
            
        builder
            .HasOne(cs => cs.TipoComprobante )
            .WithMany(tc => tc.tipoComprobanteConsecutivos)
            .HasForeignKey(cs=> cs.id_tipocomprobante);
        
        builder
            .HasOne(cs => cs.Sucursal )
            .WithMany(tc => tc.sucursalConsecutivo)
            .HasForeignKey(cs=> cs.id_sucursal);
    }
}