namespace ContabilidadWebAPI.Persistencia.Mapeo.Contabilidad;

public class CiiuMap : IEntityTypeConfiguration<CntCiiu>
{
    public void Configure(EntityTypeBuilder<CntCiiu> builder)
    {

        builder.ToTable("cnt_ciiu")
            .HasKey(pk => pk.Id);

        builder.HasOne(ciiu => ciiu.CiiuSeccionCiiu)
            .WithMany(sCiiu => sCiiu.SeccionCiiuCiiu)
            .HasForeignKey(ciiu => ciiu.IdSeccionciiu);

        builder.HasOne(ciiu => ciiu.CiiuTipoCiiu)
            .WithMany(tCiiu => tCiiu.TipoCiiuCiiu)
            .HasForeignKey(ciiu => ciiu.IdTipociuu);


    }
}