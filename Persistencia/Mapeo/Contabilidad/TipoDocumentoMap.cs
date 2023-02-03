using Dominio.Contabilidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Mapeo.Contabilidad
{
    public class TipoDocumentoMap : IEntityTypeConfiguration<CntTipoDocumento>
    {
        public void Configure(EntityTypeBuilder<CntTipoDocumento> builder)
        {
            builder.ToTable("cnt_tipodocumento")
                .HasKey( pk => pk.id);

            
        }
    }
}