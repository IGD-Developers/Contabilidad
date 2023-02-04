using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ContabilidadWebAPI.Dominio.Contabilidad;

namespace ContabilidadWebAPI.Persistencia.Mapeo.Contabilidad;

public class CentroCostoMap : IEntityTypeConfiguration<CntCentroCosto>
{
    public void Configure(EntityTypeBuilder<CntCentroCosto> builder)
    {
        builder.ToTable("cnt_centrocosto")
            .HasKey(entity => entity.Id);

        builder
            .Property(b => b.Estado)
            .HasDefaultValueSql("A");

        builder
            .Property(b => b.CreatedAt)
            .HasDefaultValueSql("DateTime.Now");

    }
}