using Dominio.Contabilidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Mapeo.Contabilidad
{
    public class TipoComprobanteMap : IEntityTypeConfiguration<CntTipoComprobante>
    {
        public void Configure(EntityTypeBuilder<CntTipoComprobante> builder)
        {
                builder
                .ToTable("cnt_tipocomprobante")
                 .HasKey(entity => entity.id);

                builder.HasOne<CntCategoriaComprobante>(t => t.categoria )
                .WithMany(ct=>ct.categoriaTipoComprobantes)
                .HasForeignKey(t =>t.id_categoriacomprobante);

                builder.HasOne(t => t.usuario )            
                .WithMany(u=>u.usuarioTipoComprobantes)
                .HasForeignKey(t =>t.id_usuario);

            builder
            .Property(b => b.created_at)
            .HasDefaultValueSql("DateTime.Now");          



          
 
        }
    }
}