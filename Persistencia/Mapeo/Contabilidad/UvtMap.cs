using Microsoft.EntityFrameworkCore;
using Dominio.Contabilidad;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Mapeo.Contabilidad

{
    public class UvtMap : IEntityTypeConfiguration<CntUvt>
    {
        public void Configure(EntityTypeBuilder<CntUvt> builder)
        {
            builder.ToTable("cnt_uvt")
                .HasKey(e=>e.id);
                
            builder
            .Property(b => b.created_at)
            .HasDefaultValueSql("DateTime.Now");  


        }
    }
}