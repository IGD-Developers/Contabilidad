namespace ContabilidadWebAPI.Persistencia.Mapeo.Contabilidad;

public class PucTipoMap : IEntityTypeConfiguration<CntPucTipo>
{
    public void Configure(EntityTypeBuilder<CntPucTipo> builder)
    {
        builder.ToTable("cnt_puctipo")
            .HasKey(entity => entity.Id);

        builder
            .Property(b => b.CreatedAt);

    }



}