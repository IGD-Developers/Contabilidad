using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Configuracion;

namespace Persistencia.Mapeo.Configuracion;

public class SucursalMap : IEntityTypeConfiguration<CnfSucursal>
{
    public void Configure(EntityTypeBuilder<CnfSucursal> builder)
    {
            builder.ToTable("cnf_sucursal")
                .HasKey(entity => entity.id);

            builder.HasOne(suc => suc.empresa )
                .WithMany(emp => emp.empresaSucursales)
                .HasForeignKey(suc=> suc.id_empresa);    
       
    }
}