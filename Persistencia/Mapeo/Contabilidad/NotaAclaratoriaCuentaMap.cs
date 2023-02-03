using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Contabilidad;

namespace Persistencia.Mapeo.Contabilidad
{
    public class NotaAclaratoriaCuentaMap : IEntityTypeConfiguration<CntNotaAclaratoriaCuenta>
    {
        public void Configure(EntityTypeBuilder<CntNotaAclaratoriaCuenta> builder)
        {
            builder
                .ToTable("cnt_notaaclaratoriacuenta")  
                .HasKey(entity => entity.id);

            /* builder.HasOne<CntNotaAclaratoria>(nac => nac.cntNotaAclaratoria)
                .WithMany(na=>na.notaAclaratoriaNotaAclaratoriaCuentas)
                .HasForeignKey(nac => nac.id_notaaclaratoria); */

            builder
                .HasOne<CntPuc>(nac => nac.cntPuc)
                .WithMany(p=>p.pucNotaAclaratoriaCuentas)
                .HasForeignKey(nac => nac.id_puc);    
        }
    }
}