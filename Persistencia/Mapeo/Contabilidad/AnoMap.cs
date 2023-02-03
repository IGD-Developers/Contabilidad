using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Contabilidad;
using Dominio.Configuracion;

namespace Persistencia.Mapeo.Contabilidad;

public class AnoMap : IEntityTypeConfiguration<CntAno>
{
    public void Configure(EntityTypeBuilder<CntAno> builder)
    {
        builder
        .ToTable("cnt_ano")  
        .HasKey(entity => entity.id);

        builder.HasOne<CnfUsuario>(a => a.usuario)
        .WithMany(u=>u.usuarioAnos)
        .HasForeignKey(a => a.id_usuario);      

        builder.HasOne<CntComprobante>(a => a.comprobante)
        .WithMany(c=>c.comprobanteAnos)
        .HasForeignKey(a => a.id_comprobante);     

        builder
        .Property(e => e.estado)
        .HasDefaultValueSql("A");  

        builder
        .Property(b => b.created_at);
 
    }
}