using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Contabilidad;

namespace Persistencia.Mapeo.Contabilidad;

public class CentroCostoMap : IEntityTypeConfiguration<CntCentroCosto>
{
    public void Configure(EntityTypeBuilder<CntCentroCosto> builder)
    {
        builder.ToTable("cnt_centrocosto")
            .HasKey(entity => entity.id);

        builder
            .Property(b => b.estado)
            .HasDefaultValueSql("A");    
                
        builder
            .Property(b => b.created_at)
            .HasDefaultValueSql("DateTime.Now");        

     }
}