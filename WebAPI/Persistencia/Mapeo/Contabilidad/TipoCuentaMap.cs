namespace ContabilidadWebAPI.Persistencia.Mapeo.Contabilidad;

public class TipoCuentaMap : IEntityTypeConfiguration<CntTipoCuenta>
{
    public void Configure(EntityTypeBuilder<CntTipoCuenta> builder)
    {
        builder.ToTable("cnt_tipocuenta")
        .HasKey(entity => entity.Id);
    }
}