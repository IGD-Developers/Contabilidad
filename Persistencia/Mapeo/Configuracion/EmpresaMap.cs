using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Configuracion;
using Dominio.Contabilidad;

namespace Persistencia.Mapeo.Configuracion;

public class EmpresaMap : IEntityTypeConfiguration<CnfEmpresa>
{
    public void Configure(EntityTypeBuilder<CnfEmpresa> builder)
    {
        builder
            .ToTable("cnf_empresa")
            .HasKey(entity => entity.Id);

            builder
            .HasOne<CntTercero>(e=> e.TerceroEmpresa)
            .WithOne(t=> t.EmpresaTercero)
            .HasForeignKey<CnfEmpresa>(e => e.IdTerceroGerente);    

         }

        
}