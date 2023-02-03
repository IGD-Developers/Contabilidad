using Dominio.Contabilidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Mapeo.Contabilidad;

public class MunicipioMap : IEntityTypeConfiguration<CntMunicipio>
{
    public void Configure(EntityTypeBuilder<CntMunicipio> builder)
    {
        builder.ToTable("cnt_municipio")
            .HasKey( pk => pk.id);

        builder.HasOne<CntDepartamento>(mun => mun.departamento)
                .WithMany(dep => dep.departamentoMunicipios)
                .HasForeignKey(mun => mun.id_departamento);

        
    }
}