using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Contabilidad;

namespace Persistencia.Mapeo.Contabilidad;

public class NotaAclaratoriaMap : IEntityTypeConfiguration<CntNotaAclaratoria>
{
    public void Configure(EntityTypeBuilder<CntNotaAclaratoria> builder)
    {
        builder
            .ToTable("cnt_notaaclaratoria")  
            .HasKey(entity => entity.id);

        builder.HasOne<CntNotaAclaratoriaTipo>(na => na.notaAclaratoriaTipo)
                .WithMany(nat=>nat.notaAclaratoriaTipoNotaAclaratorias)
                .HasForeignKey(na => na.id_notaaclaratoriatipo);

        builder.HasOne<CntPuc>(na => na.cntPuct)
                .WithMany(nat=>nat.pucNotaAclaratoria)
                .HasForeignKey(na => na.id_puc);

        builder
            .Property(b => b.created_at)
            .HasDefaultValueSql("DateTime.Now");     

        builder
            .Property(b => b.estado)
            .HasDefaultValueSql("A");
               

               
    }
}