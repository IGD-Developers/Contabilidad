using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Contabilidad;
using Dominio.Configuracion;

namespace Persistencia.Mapeo.Contabilidad
{
    public class LiquidaImpuestoMap : IEntityTypeConfiguration<CntLiquidaImpuesto>
    {
        public void Configure(EntityTypeBuilder<CntLiquidaImpuesto> builder)
        {
            builder
                .ToTable("cnt_liquidaimpuesto")
                .HasKey(entity => entity.id);

            builder
                .HasOne<CntTipoImpuesto>(li => li.tipoImpuesto)
                .WithMany(ti => ti.tipoImpuestoLiquidaImpuestos)
                .HasForeignKey(li => li.id_tipoimpuesto);

            builder
                .HasOne<CntTercero>(li => li.tercero)
                .WithMany(t => t.liquidaImpuestoTerceros)
                .HasForeignKey(li => li.id_tercero);

            builder
                .HasOne<CntPuc>(li => li.puc)
                .WithMany(p => p.pucLiquidaImpuestos)
                .HasForeignKey(li => li.id_puc);

            builder
                .HasOne<CntComprobante>(li => li.comprobante)
                .WithMany(c => c.comprobanteLiquidaImpuestos)
                .HasForeignKey(li => li.id_comprobante);

           builder
               .Property(b => b.estado)
                .HasDefaultValueSql("A");

            builder
               .Property(b => b.created_at)
                .HasDefaultValueSql("DateTime.Now");

        }
    }
}