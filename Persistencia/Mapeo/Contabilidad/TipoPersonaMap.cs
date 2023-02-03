using Dominio.Contabilidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Mapeo.Contabilidad;

public class TipoPersonaMap : IEntityTypeConfiguration<CntTipoPersona>
{
    public void Configure(EntityTypeBuilder<CntTipoPersona> builder)
    {
        builder.ToTable("cnt_tipopersona")
            .HasKey( pk => pk.id );
        
    }
}