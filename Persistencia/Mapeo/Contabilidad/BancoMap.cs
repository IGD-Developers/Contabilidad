using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Contabilidad;

namespace Persistencia.Mapeo.Contabilidad;

public class BancoMap : IEntityTypeConfiguration<CntBanco>
{
    public void Configure(EntityTypeBuilder<CntBanco> builder)
    {
        builder
            .ToTable("cnt_banco")  
            .HasKey(entity => entity.id);
    }
}