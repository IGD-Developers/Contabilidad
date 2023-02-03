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
                .HasKey(entity => entity.id);

            builder
                .HasOne<CntTercero>(e => e.tercero)
                .WithMany(t=>t.entidadTerceros)
                .HasForeignKey(e => e.id_tercero);  

            builder
                .HasOne<CntTipoImpuesto>(e => e.tipoImpuesto)
                .WithMany(ti=>ti.tipoImpuestoEntidades)
                .HasForeignKey(e => e.id_tipoimpuesto);   
        }                    
    }
}