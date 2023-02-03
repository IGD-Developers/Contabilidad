using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Contabilidad;

namespace Persistencia.Mapeo.Contabilidad
{
    public class DetalleComprobantMap : IEntityTypeConfiguration<CntDetalleComprobante>
    {
        public void Configure(EntityTypeBuilder<CntDetalleComprobante> builder)
        {
            builder
                .ToTable("cnt_detallecomprobante")
                .HasKey(e => e.id);     

            builder.HasOne<CntComprobante>(d =>d.comprobante)
                .WithMany(c=>c.comprobanteDetalleComprobantes)
                .HasForeignKey(d => d.id_comprobante);

            builder.HasOne<CntCentroCosto>(d => d.centroCosto)
                .WithMany(c=>c.centroCostoDetalleComprobantes)
                .HasForeignKey(d => d.id_centrocosto);
                
            builder.HasOne<CntPuc>(d => d.puc)
                .WithMany(p=>p.pucDetalleComprobantes)
                .HasForeignKey(d => d.id_puc);
           
            builder.HasOne<CntTercero>(d => d.tercero)
                .WithMany(p=>p.detalleComprobanteTerceros)
                .HasForeignKey(d => d.id_tercero);
            }
    }
}