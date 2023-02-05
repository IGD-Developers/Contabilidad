namespace ContabilidadWebAPI.Persistencia.Mapeo.Contabilidad;

public class FormatoColumnaMap : IEntityTypeConfiguration<CntFormatoColumna>
{
    public void Configure(EntityTypeBuilder<CntFormatoColumna> builder)
    {
        builder
        .ToTable("cnt_formatocolumna")
        .HasKey(entity => entity.Id);

        builder.HasOne(fc => fc.ExogenaFormato)
            .WithMany(ef => ef.ExogenaFormatoFormatoColumnas)
            .HasForeignKey(fc => fc.IdExogenaformato);
    }
}