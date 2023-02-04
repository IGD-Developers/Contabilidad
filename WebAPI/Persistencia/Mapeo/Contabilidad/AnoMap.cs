using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ContabilidadWebAPI.Dominio.Configuracion;
using ContabilidadWebAPI.Dominio.Contabilidad;

namespace ContabilidadWebAPI.Persistencia.Mapeo.Contabilidad;

public class AnoMap : IEntityTypeConfiguration<CntAno>
{
    public void Configure(EntityTypeBuilder<CntAno> builder)
    {
        builder
        .ToTable("cnt_ano")
        .HasKey(entity => entity.Id);

        builder.HasOne(a => a.Usuario)
        .WithMany(u => u.UsuarioAnos)
        .HasForeignKey(a => a.IdUsuario);

        builder.HasOne(a => a.Comprobante)
        .WithMany(c => c.ComprobanteAnos)
        .HasForeignKey(a => a.IdComprobante);

        builder
        .Property(e => e.Estado)
        .HasDefaultValueSql("A");

        builder
        .Property(b => b.CreatedAt);

    }
}