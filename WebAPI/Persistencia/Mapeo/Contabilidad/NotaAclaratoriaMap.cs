using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ContabilidadWebAPI.Dominio.Contabilidad;

namespace ContabilidadWebAPI.Persistencia.Mapeo.Contabilidad;

public class NotaAclaratoriaMap : IEntityTypeConfiguration<CntNotaAclaratoria>
{
    public void Configure(EntityTypeBuilder<CntNotaAclaratoria> builder)
    {
        builder
            .ToTable("cnt_notaaclaratoria")
            .HasKey(entity => entity.Id);

        builder.HasOne(na => na.NotaAclaratoriaTipo)
                .WithMany(nat => nat.NotaAclaratoriaTipoNotaAclaratorias)
                .HasForeignKey(na => na.IdNotaaclaratoriatipo);

        builder.HasOne(na => na.CntPuct)
                .WithMany(nat => nat.PucNotaAclaratoria)
                .HasForeignKey(na => na.IdPuc);

        builder
            .Property(b => b.CreatedAt)
            .HasDefaultValueSql("DateTime.Now");

        builder
            .Property(b => b.Estado)
            .HasDefaultValueSql("A");



    }
}