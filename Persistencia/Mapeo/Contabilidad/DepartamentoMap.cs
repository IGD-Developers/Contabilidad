using Dominio.Contabilidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Mapeo.Contabilidad
{
    public class DepartamentoMap : IEntityTypeConfiguration<CntDepartamento>
    {
        public void Configure(EntityTypeBuilder<CntDepartamento> builder)
        {
            builder.ToTable("cnt_departamento")
                .HasKey( pk => pk.Id);
            
        }
    }
}