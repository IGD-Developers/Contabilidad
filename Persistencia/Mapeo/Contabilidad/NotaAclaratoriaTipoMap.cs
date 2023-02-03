using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Contabilidad;

namespace Persistencia.Mapeo.Contabilidad
{
    public class NotaAclaratoriaTipoMap : IEntityTypeConfiguration<CntNotaAclaratoriaTipo>
    {
        public void Configure(EntityTypeBuilder<CntNotaAclaratoriaTipo> builder)
        {
            builder
                .ToTable("cnt_notaaclaratoriatipo")  
                .HasKey(entity => entity.id);
        }
    }
}