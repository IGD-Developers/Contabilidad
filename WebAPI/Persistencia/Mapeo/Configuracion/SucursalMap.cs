namespace ContabilidadWebAPI.Persistencia.Mapeo.Configuracion;

public class SucursalMap : IEntityTypeConfiguration<CnfSucursal>
{
    public void Configure(EntityTypeBuilder<CnfSucursal> builder)
    {
        builder.ToTable("cnf_sucursal")
            .HasKey(entity => entity.Id);

        builder.HasOne(suc => suc.Empresa)
            .WithMany(emp => emp.EmpresaSucursales)
            .HasForeignKey(suc => suc.IdEmpresa);

    }
}