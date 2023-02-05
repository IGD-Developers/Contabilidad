namespace ContabilidadWebAPI.Persistencia.Mapeo.Configuracion;

public class EmpresaMap : IEntityTypeConfiguration<CnfEmpresa>
{
    public void Configure(EntityTypeBuilder<CnfEmpresa> builder)
    {
        builder
            .ToTable("cnf_empresa")
            .HasKey(entity => entity.Id);

        builder
        .HasOne(e => e.TerceroEmpresa)
        .WithOne(t => t.EmpresaTercero)
        .HasForeignKey<CnfEmpresa>(e => e.IdTerceroGerente);

    }


}