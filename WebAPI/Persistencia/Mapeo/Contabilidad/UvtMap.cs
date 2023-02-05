namespace ContabilidadWebAPI.Persistencia.Mapeo.Contabilidad;


public class UvtMap : IEntityTypeConfiguration<CntUvt>
{
    public void Configure(EntityTypeBuilder<CntUvt> builder)
    {
        builder.ToTable("cnt_uvt")
            .HasKey(e => e.Id);

        builder
        .Property(b => b.CreatedAt)
        .HasDefaultValueSql("DateTime.Now");


    }
}