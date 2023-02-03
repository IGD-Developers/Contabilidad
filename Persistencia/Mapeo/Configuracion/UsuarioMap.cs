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

                builder.HasOne<CntTercero>(t => t.tercero)
                .WithMany(ter => ter.usuarioTerceros)
                .HasForeignKey(rter => rter.id_tercero);
            builder
                .Property(b => b.created_at)     
                .HasDefaultValueSql("DateTime.Now");     
            
        }
    }
}