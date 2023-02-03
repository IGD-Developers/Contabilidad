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
        .HasKey(entity => entity.Id);

        builder.HasOne<CnfUsuario>(a => a.Usuario)
        .WithMany(u=>u.UsuarioAnos)
        .HasForeignKey(a => a.IdUsuario);      

        builder.HasOne<CntComprobante>(a => a.Comprobante)
        .WithMany(c=>c.ComprobanteAnos)
        .HasForeignKey(a => a.IdComprobante);     

        builder
        .Property(e => e.Estado)
        .HasDefaultValueSql("A");  

        builder
        .Property(b => b.CreatedAt);
 
    }
}