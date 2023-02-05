namespace ContabilidadWebAPI.Persistencia.Mapeo.Contabilidad;

public class CategoriaComprobanteMap : IEntityTypeConfiguration<CntCategoriaComprobante>
{
    public void Configure(EntityTypeBuilder<CntCategoriaComprobante> builder)
    {
        builder
        .ToTable("cnt_categoriacomprobante")
        .HasKey(entity => entity.Id);


    }
}