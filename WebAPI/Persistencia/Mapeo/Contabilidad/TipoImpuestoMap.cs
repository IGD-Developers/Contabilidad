namespace ContabilidadWebAPI.Persistencia.Mapeo.Contabilidad;

public class TipoImpuestoMap : IEntityTypeConfiguration<CntTipoImpuesto>
{
    public void Configure(EntityTypeBuilder<CntTipoImpuesto> builder)
    {
        builder
            .ToTable("cnt_tipoimpuesto")
            .HasKey(entity => entity.Id);
    }
}