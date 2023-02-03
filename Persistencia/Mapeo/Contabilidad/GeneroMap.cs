using Dominio.Contabilidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Mapeo.Contabilidad
{
    public class GeneroMap : IEntityTypeConfiguration<CntGenero>
    {
        public void Configure(EntityTypeBuilder<CntGenero> builder)
        {
            builder.ToTable("cnt_genero")
                .HasKey( pk => pk.id);
            
        }
    }
}