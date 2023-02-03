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
                .HasKey(e => e.id);

            builder.HasOne<CntPucTipo>(p => p.pucTipo)
                .WithMany(t => t.cntPucTipoPucs)
                .HasForeignKey(p => p.id_puctipo);

            builder.HasOne<CntTipoCuenta>(p => p.tipoCuenta)
                    .WithMany(t => t.TipoCuentaPucs)
                    .HasForeignKey(p => p.id_tipocuenta);
            
            builder.HasOne<CntTipoImpuesto>(p => p.tipoImpuesto)
                    .WithMany(t => t.tipoImpuestoPuc)
                    .HasForeignKey(p => p.id_tipoimpuesto);

            builder.HasOne<CnfUsuario>(p => p.usuario)
                .WithMany(u => u.usuarioPucs)
                .HasForeignKey(p => p.id_usuario);

            // builder
            //     .Property(b => b.id_tipoimpuesto)
            //     .HasDefaultValueSql(0);
            
            builder
                .Property(b => b.created_at)
                .HasDefaultValueSql("DateTime.Now");

            





        }
    }
}