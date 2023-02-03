using Dominio.Contabilidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Mapeo.Contabilidad
{
    public class CiiuMap : IEntityTypeConfiguration<CntCiiu>
    {
        public void Configure(EntityTypeBuilder<CntCiiu> builder)
        {
        
            builder.ToTable("cnt_ciiu")
                .HasKey( pk => pk.id);
                
            builder.HasOne<CntSeccionCiiu>(ciiu => ciiu.ciiuSeccionCiiu)
                .WithMany(sCiiu => sCiiu.seccionCiiuCiiu)
                .HasForeignKey(ciiu => ciiu.id_seccionciiu);
                
            builder.HasOne<CntTipoCiiu>(ciiu => ciiu.ciiuTipoCiiu)
                .WithMany(tCiiu => tCiiu.tipoCiiuCiiu)
                .HasForeignKey(ciiu => ciiu.id_tipociuu);
                    
            
        }
    }
}