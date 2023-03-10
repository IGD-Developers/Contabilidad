namespace ContabilidadWebAPI.Persistencia.Mapeo.Contabilidad;

public class ComprobanteMap : IEntityTypeConfiguration<CntComprobante>
{


    public void Configure(EntityTypeBuilder<CntComprobante> builder)
    {
        builder
            .ToTable("cnt_comprobante")
            .HasKey(e => e.Id);

        builder
            .HasOne(c => c.Usuario)
            .WithMany(u => u.UsuarioComprobantes)
            .HasForeignKey(c => c.IdUsuario);
        builder
            .HasOne(c => c.TipoComprobante)
                .WithMany(t => t.ComprobantesTipoComprobante)
                .HasForeignKey(c => c.IdTipocomprobante);
        builder
           .HasOne(c => c.Sucursal)
                .WithMany(s => s.SucursalComprobantes)
                .HasForeignKey(c => c.IdSucursal);
        builder
        .Property(b => b.CreatedAt)
        .HasDefaultValueSql("DateTime.Now");

        builder
        .Property(e => e.Estado)
        .HasDefaultValueSql("A");

        // builder
        // .Property(e => e.IdModulo)
        // .HasDefaultValueSql("1");  
    }

}
