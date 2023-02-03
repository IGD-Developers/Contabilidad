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
                .HasKey(e => e.Id);     

            builder.HasOne<CntComprobante>(d =>d.Comprobante)
                .WithMany(c=>c.ComprobanteDetalleComprobantes)
                .HasForeignKey(d => d.IdComprobante);

            builder.HasOne<CntCentroCosto>(d => d.CentroCosto)
                .WithMany(c=>c.CentroCostoDetalleComprobantes)
                .HasForeignKey(d => d.IdCentrocosto);
                
            builder.HasOne<CntPuc>(d => d.Puc)
                .WithMany(p=>p.PucDetalleComprobantes)
                .HasForeignKey(d => d.IdPuc);
           
            builder.HasOne<CntTercero>(d => d.Tercero)
                .WithMany(p=>p.DetalleComprobanteTerceros)
                .HasForeignKey(d => d.IdTercero);
            }
    }
}