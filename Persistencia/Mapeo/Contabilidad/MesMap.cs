using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Contabilidad;
using Dominio.Configuracion;

namespace Persistencia.Mapeo.Contabilidad
{
    public class MesMap : IEntityTypeConfiguration<CntMes>
    {
        public void Configure(EntityTypeBuilder<CntMes> builder)
        {
            builder
                .ToTable("cnt_mes")
                .HasKey(entity => entity.Id);

            builder
            .HasOne<CnfUsuario>(m => m.Usuario)
                .WithMany(u=>u.UsuarioMeses)
                .HasForeignKey(m => m.IdUsuario); 

            builder
                .Property(b => b.CreatedAt);
             
             builder
                .Property(b => b.CreatedAt);      
     
        }
    }
}