using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Contabilidad;

namespace Persistencia.Mapeo.Contabilidad
{
    public class EntidadMap : IEntityTypeConfiguration<CntEntidad>
    {
        public void Configure(EntityTypeBuilder<CntEntidad> builder)
        {
            builder
                .ToTable("cnt_entidad")
                .HasKey(entity => entity.Id);

            builder
                .HasOne<CntTercero>(e => e.Tercero)
                .WithMany(t=>t.EntidadTerceros)
                .HasForeignKey(e => e.IdTercero);  

            builder
                .HasOne<CntTipoImpuesto>(e => e.TipoImpuesto)
                .WithMany(ti=>ti.TipoImpuestoEntidades)
                .HasForeignKey(e => e.IdTipoimpuesto);   
        }                    
    }
}