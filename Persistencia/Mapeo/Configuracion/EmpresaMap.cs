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
            .HasKey(entity => entity.id);

            builder
            .HasOne<CntTercero>(e=> e.terceroEmpresa)
            .WithOne(t=> t.empresaTercero)
            .HasForeignKey<CnfEmpresa>(e => e.id_tercero_gerente);    

         }

        
}