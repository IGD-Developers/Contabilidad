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
                .HasKey(entity => entity.id);

            builder
            .HasOne<CnfUsuario>(m => m.usuario)
                .WithMany(u=>u.usuarioMeses)
                .HasForeignKey(m => m.id_usuario); 

            builder
                .Property(b => b.created_at);
             
             builder
                .Property(b => b.created_at);      
     
        }
    }
}