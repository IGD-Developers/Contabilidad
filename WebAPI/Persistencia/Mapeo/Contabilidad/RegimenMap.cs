namespace ContabilidadWebAPI.Persistencia.Mapeo.Contabilidad;

public class RegimenMap : IEntityTypeConfiguration<CntRegimen>
{
    public void Configure(EntityTypeBuilder<CntRegimen> builder)
    {
        builder.ToTable("cnt_regimen")
            .HasKey(pk => pk.Id);

    }
}