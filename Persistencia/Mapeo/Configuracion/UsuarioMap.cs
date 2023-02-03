using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Configuracion;
using Microsoft.AspNetCore.Identity;
using Dominio.Contabilidad;

namespace Persistencia.Mapeo.Configuracion
{
    public class UsuarioMap : IEntityTypeConfiguration<CnfUsuario>
    {
        public void Configure(EntityTypeBuilder<CnfUsuario> builder)
        {
            builder
                .ToTable("aspnetusers")
                .HasKey(entity => entity.Id);

                builder.HasOne<CntTercero>(t => t.Tercero)
                .WithMany(ter => ter.usuarioTerceros)
                .HasForeignKey(rter => rter.IdTercero);
            builder
                .Property(b => b.CreatedAt)     
                .HasDefaultValueSql("DateTime.Now");     
            
        }
    }
}