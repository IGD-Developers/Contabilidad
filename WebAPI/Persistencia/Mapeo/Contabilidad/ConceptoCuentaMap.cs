namespace ContabilidadWebAPI.Persistencia.Mapeo.Contabilidad;

public class ConceptoCuentaMap : IEntityTypeConfiguration<CntConceptoCuenta>
{
    public void Configure(EntityTypeBuilder<CntConceptoCuenta> builder)
    {
        builder
        .ToTable("cnt_conceptocuenta")
        .HasKey(entity => entity.Id);
    }
}