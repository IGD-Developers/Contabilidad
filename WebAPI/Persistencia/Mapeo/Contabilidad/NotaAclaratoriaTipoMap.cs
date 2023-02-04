using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ContabilidadWebAPI.Dominio.Contabilidad;

namespace ContabilidadWebAPI.Persistencia.Mapeo.Contabilidad;

public class NotaAclaratoriaTipoMap : IEntityTypeConfiguration<CntNotaAclaratoriaTipo>
{
    public void Configure(EntityTypeBuilder<CntNotaAclaratoriaTipo> builder)
    {
        builder
            .ToTable("cnt_notaaclaratoriatipo")
            .HasKey(entity => entity.Id);
    }
}