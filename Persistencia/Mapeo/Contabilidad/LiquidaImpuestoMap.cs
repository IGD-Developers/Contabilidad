using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Contabilidad;
using Dominio.Configuracion;

namespace Persistencia.Mapeo.Contabilidad;

public class LiquidaImpuestoMap : IEntityTypeConfiguration<CntLiquidaImpuesto>
{
    public void Configure(EntityTypeBuilder<CntLiquidaImpuesto> builder)
    {
        builder
            .ToTable("cnt_liquidaimpuesto")
            .HasKey(entity => entity.Id);

        builder
            .HasOne<CntTipoImpuesto>(li => li.TipoImpuesto)
            .WithMany(ti => ti.TipoImpuestoLiquidaImpuestos)
            .HasForeignKey(li => li.IdTipoimpuesto);

        builder
            .HasOne<CntTercero>(li => li.Tercero)
            .WithMany(t => t.LiquidaImpuestoTerceros)
            .HasForeignKey(li => li.IdTercero);

        builder
            .HasOne<CntPuc>(li => li.Puc)
            .WithMany(p => p.PucLiquidaImpuestos)
            .HasForeignKey(li => li.IdPuc);

        builder
            .HasOne<CntComprobante>(li => li.Comprobante)
            .WithMany(c => c.ComprobanteLiquidaImpuestos)
            .HasForeignKey(li => li.IdComprobante);

       builder
           .Property(b => b.Estado)
            .HasDefaultValueSql("A");

        builder
           .Property(b => b.CreatedAt)
            .HasDefaultValueSql("DateTime.Now");

    }
}