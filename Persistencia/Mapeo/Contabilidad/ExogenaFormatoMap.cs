using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Contabilidad;

namespace Persistencia.Mapeo.Contabilidad;

public class ExogenaFormatoMap : IEntityTypeConfiguration<CntExogenaFormato>
{
    public void Configure(EntityTypeBuilder<CntExogenaFormato> builder)
    {
        builder.ToTable("cnt_exogenaformato")  
            .HasKey(entity => entity.id);
    }
}