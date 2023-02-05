namespace ContabilidadWebAPI.Persistencia.Mapeo.Contabilidad;

public class SeccionCiiuMap : IEntityTypeConfiguration<CntSeccionCiiu>
{
    public void Configure(EntityTypeBuilder<CntSeccionCiiu> builder)
    {
        builder.ToTable("cnt_seccionciiu")
            .HasKey(pk => pk.Id);
    }



}