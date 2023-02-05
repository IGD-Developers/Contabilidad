namespace ContabilidadWebAPI.Persistencia.Mapeo.Contabilidad;

public class TipoComprobanteMap : IEntityTypeConfiguration<CntTipoComprobante>
{
    public void Configure(EntityTypeBuilder<CntTipoComprobante> builder)
    {
        builder
        .ToTable("cnt_tipocomprobante")
         .HasKey(entity => entity.Id);

        builder.HasOne(t => t.Categoria)
        .WithMany(ct => ct.CategoriaTipoComprobantes)
        .HasForeignKey(t => t.IdCategoriacomprobante);

        builder.HasOne(t => t.Usuario)
        .WithMany(u => u.UsuarioTipoComprobantes)
        .HasForeignKey(t => t.IdUsuario);

        builder
        .Property(b => b.CreatedAt)
        .HasDefaultValueSql("DateTime.Now");





    }
}