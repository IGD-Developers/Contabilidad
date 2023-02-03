using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Configuracion;
using Dominio.Contabilidad;
using System;

namespace Persistencia.Mapeo.Contabilidad
{
    public class PucMap : IEntityTypeConfiguration<CntPuc>
    {
        public void Configure(EntityTypeBuilder<CntPuc> builder)
        {

            builder.ToTable("cnt_puc")
                .HasKey(e => e.Id);

            builder.HasOne<CntPucTipo>(p => p.PucTipo)
                .WithMany(t => t.CntPucTipoPucs)
                .HasForeignKey(p => p.IdPuctipo);

            builder.HasOne<CntTipoCuenta>(p => p.TipoCuenta)
                    .WithMany(t => t.TipoCuentaPucs)
                    .HasForeignKey(p => p.IdTipocuenta);
            
            builder.HasOne<CntTipoImpuesto>(p => p.TipoImpuesto)
                    .WithMany(t => t.TipoImpuestoPuc)
                    .HasForeignKey(p => p.IdTipoimpuesto);

            builder.HasOne<CnfUsuario>(p => p.Usuario)
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
}