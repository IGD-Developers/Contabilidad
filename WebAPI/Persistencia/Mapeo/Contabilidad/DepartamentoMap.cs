namespace ContabilidadWebAPI.Persistencia.Mapeo.Contabilidad;

public class DepartamentoMap : IEntityTypeConfiguration<CntDepartamento>
{
    public void Configure(EntityTypeBuilder<CntDepartamento> builder)
    {
        builder.ToTable("cnt_departamento")
            .HasKey(pk => pk.Id);

    }
}