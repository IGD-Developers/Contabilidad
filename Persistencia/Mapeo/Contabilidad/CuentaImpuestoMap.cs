using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Contabilidad;

namespace Persistencia.Mapeo.Contabilidad;

public class CuentaImpuestoMap : IEntityTypeConfiguration<CntCuentaImpuesto>
{
    public void Configure(EntityTypeBuilder<CntCuentaImpuesto> builder)
    {
        builder
            .ToTable("cnt_cuentaimpuesto")
            .HasKey(entity => entity.Id);

            builder
                .HasOne<CntPuc>(c => c.Puc)
                .WithMany(p=>p.PucCuentaImpuestos)
                .HasForeignKey(p => p.IdPuc);    

            builder.HasOne<CntTipoImpuesto>(c => c.TipoImpuesto)
                .WithMany(t=>t.CntTipoImpuestoCntCuentaImpuestos)
                .HasForeignKey(c => c.IdTipoimpuesto);    
        }
}