namespace ContabilidadWebAPI.Persistencia.Mapeo.Configuracion;

public class UsuarioMap : IEntityTypeConfiguration<CnfUsuario>
{
    public void Configure(EntityTypeBuilder<CnfUsuario> builder)
    {
        builder
            .ToTable("aspnetusers")
            .HasKey(entity => entity.Id);

        builder.HasOne(t => t.Tercero)
        .WithMany(ter => ter.UsuarioTerceros)
        .HasForeignKey(rter => rter.IdTercero);
        builder
            .Property(b => b.CreatedAt)
            .HasDefaultValueSql("DateTime.Now");

    }
}