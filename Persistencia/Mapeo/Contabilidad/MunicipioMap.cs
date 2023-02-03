using Dominio.Contabilidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Mapeo.Contabilidad
{
    public class MunicipioMap : IEntityTypeConfiguration<CntMunicipio>
    {
        public void Configure(EntityTypeBuilder<CntMunicipio> builder)
        {
            builder.ToTable("cnt_municipio")
                .HasKey( pk => pk.Id);

            builder.HasOne<CntDepartamento>(mun => mun.Departamento)
                    .WithMany(dep => dep.DepartamentoMunicipios)
                    .HasForeignKey(mun => mun.IdDepartamento);

            
        }
    }
}