using ContabilidadWebAPI.Dominio.Contabilidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContabilidadWebAPI.Persistencia.Mapeo.Contabilidad;

public class TipoCiiuMap : IEntityTypeConfiguration<CntTipoCiiu>
{
    public void Configure(EntityTypeBuilder<CntTipoCiiu> builder)
    {
        builder.ToTable("cnt_tipociiu")
            .HasKey(pk => pk.Id);

    }
}