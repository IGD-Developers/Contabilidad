namespace ContabilidadWebAPI.Persistencia.Mapeo.Contabilidad;

public class MesMap : IEntityTypeConfiguration<CntMes>
{
    public void Configure(EntityTypeBuilder<CntMes> builder)
    {
        builder
            .ToTable("cnt_mes")
            .HasKey(entity => entity.Id);

        builder
        .HasOne(m => m.Usuario)
            .WithMany(u => u.UsuarioMeses)
            .HasForeignKey(m => m.IdUsuario);

        builder
            .Property(b => b.CreatedAt);

        builder
           .Property(b => b.CreatedAt);

    }
}