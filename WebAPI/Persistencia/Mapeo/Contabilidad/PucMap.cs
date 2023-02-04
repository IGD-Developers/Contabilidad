using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Dominio.Configuracion;

namespace ContabilidadWebAPI.Persistencia.Mapeo.Contabilidad;

public class PucMap : IEntityTypeConfiguration<CntPuc>
{
    public void Configure(EntityTypeBuilder<CntPuc> builder)
    {

        builder.ToTable("cnt_puc")
            .HasKey(e => e.Id);

        builder.HasOne(p => p.PucTipo)
            .WithMany(t => t.CntPucTipoPucs)
            .HasForeignKey(p => p.IdPuctipo);

        builder.HasOne(p => p.TipoCuenta)
                .WithMany(t => t.TipoCuentaPucs)
                .HasForeignKey(p => p.IdTipocuenta);

        builder.HasOne(p => p.TipoImpuesto)
                .WithMany(t => t.TipoImpuestoPuc)
                .HasForeignKey(p => p.IdTipoimpuesto);

        builder.HasOne(p => p.Usuario)
            .WithMany(u => u.UsuarioPucs)
            .HasForeignKey(p => p.IdUsuario);

        // builder
        //     .Property(b => b.IdTipoimpuesto)
        //     .HasDefaultValueSql(0);

        builder
            .Property(b => b.CreatedAt)
            .HasDefaultValueSql("DateTime.Now");







    }
}