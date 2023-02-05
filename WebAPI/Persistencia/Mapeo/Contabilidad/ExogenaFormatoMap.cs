namespace ContabilidadWebAPI.Persistencia.Mapeo.Contabilidad;

public class ExogenaFormatoMap : IEntityTypeConfiguration<CntExogenaFormato>
{
    public void Configure(EntityTypeBuilder<CntExogenaFormato> builder)
    {
        builder.ToTable("cnt_exogenaformato")
            .HasKey(entity => entity.Id);
    }
}