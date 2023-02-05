namespace ContabilidadWebAPI.Persistencia.Mapeo.Contabilidad;

public class GeneroMap : IEntityTypeConfiguration<CntGenero>
{
    public void Configure(EntityTypeBuilder<CntGenero> builder)
    {
        builder.ToTable("cnt_genero")
            .HasKey(pk => pk.Id);

    }
}