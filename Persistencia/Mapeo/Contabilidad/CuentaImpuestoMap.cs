using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Contabilidad;

namespace Persistencia.Mapeo.Contabilidad
{
    public class CuentaImpuestoMap : IEntityTypeConfiguration<CntCuentaImpuesto>
    {
        public void Configure(EntityTypeBuilder<CntCuentaImpuesto> builder)
        {
            builder
                .ToTable("cnt_cuentaimpuesto")
                .HasKey(entity => entity.id);

                builder
                    .HasOne<CntPuc>(c => c.puc)
                    .WithMany(p=>p.pucCuentaImpuestos)
                    .HasForeignKey(p => p.id_puc);    

                builder.HasOne<CntTipoImpuesto>(c => c.tipoImpuesto)
                    .WithMany(t=>t.cntTipoImpuestoCntCuentaImpuestos)
                    .HasForeignKey(c => c.id_tipoimpuesto);    
            }
    }
}