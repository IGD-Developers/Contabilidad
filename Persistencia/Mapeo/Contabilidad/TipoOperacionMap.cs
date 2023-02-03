using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Contabilidad;

namespace Persistencia.Mapeo.Contabilidad
{
    public class TipoOperacionMap : IEntityTypeConfiguration<CntTipoOperacion>
    {
        public void Configure(EntityTypeBuilder<CntTipoOperacion> builder)
        {
                builder
                .ToTable("cnt_tipooperacion")  
                .HasKey(entity => entity.Id);
        }
    }
}