using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ContabilidadWebAPI.Dominio.Contabilidad;

namespace ContabilidadWebAPI.Persistencia.Mapeo.Contabilidad;

public class NotaAclaratoriaCuentaMap : IEntityTypeConfiguration<CntNotaAclaratoriaCuenta>
{
    public void Configure(EntityTypeBuilder<CntNotaAclaratoriaCuenta> builder)
    {
        builder
            .ToTable("cnt_notaaclaratoriacuenta")
            .HasKey(entity => entity.Id);

        /* builder.HasOne<CntNotaAclaratoria>(nac => nac.cntNotaAclaratoria)
            .WithMany(na=>na.notaAclaratoriaNotaAclaratoriaCuentas)
            .HasForeignKey(nac => nac.id_notaaclaratoria); */

        builder
            .HasOne(nac => nac.CntPuc)
            .WithMany(p => p.PucNotaAclaratoriaCuentas)
            .HasForeignKey(nac => nac.IdPuc);
    }
}