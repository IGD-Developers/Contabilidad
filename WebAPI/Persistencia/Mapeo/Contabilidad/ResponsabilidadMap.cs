namespace ContabilidadWebAPI.Persistencia.Mapeo.Contabilidad;

public class ResponsabilidadMap : IEntityTypeConfiguration<CntResponsabilidad>
{
    public void Configure(EntityTypeBuilder<CntResponsabilidad> builder)
    {
        builder.ToTable("cnt_responsabilidad")
            .HasKey(pk => pk.Id);

    }
}