using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Contabilidad;
using Dominio.Configuracion;

namespace Persistencia.Mapeo.Contabilidad
{
    public class ComprobanteMap : IEntityTypeConfiguration<CntComprobante>
    {

        
        public void Configure(EntityTypeBuilder<CntComprobante> builder)
        {
            builder
                .ToTable("cnt_comprobante")
                .HasKey(e => e.id);     

            builder
                .HasOne<CnfUsuario>(c =>c.usuario)
                .WithMany(u=>u.usuarioComprobantes)
                .HasForeignKey(c => c.id_usuario);
            builder
                .HasOne<CntTipoComprobante>(c => c.tipoComprobante)
                    .WithMany(t=>t.ComprobantesTipoComprobante)
                    .HasForeignKey(c => c.id_tipocomprobante);
            builder
               .HasOne(c => c.sucursal)
                    .WithMany(s=>s.sucursalComprobantes)
                    .HasForeignKey(c => c.id_sucursal);
            builder
            .Property(b => b.created_at)
            .HasDefaultValueSql("DateTime.Now");  
            
            builder
            .Property(e => e.estado)
            .HasDefaultValueSql("A");  

            // builder
            // .Property(e => e.id_modulo)
            // .HasDefaultValueSql("1");  
        }           

    }
}
