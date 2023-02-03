using Dominio.Contabilidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Mapeo.Contabilidad;

public class CiiuMap : IEntityTypeConfiguration<CntCiiu>
{
    public void Configure(EntityTypeBuilder<CntCiiu> builder)
    {
    
        builder.ToTable("cnt_ciiu")
            .HasKey( pk => pk.Id);
            
        builder.HasOne<CntSeccionCiiu>(ciiu => ciiu.CiiuSeccionCiiu)
            .WithMany(sCiiu => sCiiu.SeccionCiiuCiiu)
            .HasForeignKey(ciiu => ciiu.IdSeccionciiu);
            
        builder.HasOne<CntTipoCiiu>(ciiu => ciiu.CiiuTipoCiiu)
            .WithMany(tCiiu => tCiiu.TipoCiiuCiiu)
            .HasForeignKey(ciiu => ciiu.IdTipociuu);
                
        
    }
}