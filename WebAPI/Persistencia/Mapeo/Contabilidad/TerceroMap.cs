using ContabilidadWebAPI.Dominio.Contabilidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContabilidadWebAPI.Persistencia.Mapeo.Contabilidad;

public class TerceroMap : IEntityTypeConfiguration<CntTercero>
{
    public void Configure(EntityTypeBuilder<CntTercero> builder)
    {
        builder.ToTable("cnt_tercero")
            .HasKey(pk => pk.Id);

        builder.HasOne(terc => terc.Documentos)
            .WithMany(tDoc => tDoc.DocumentoTerceros)
            .HasForeignKey(ter => ter.IdTipodocumento);

        builder.HasOne(terc => terc.Genero)
            .WithMany(gen => gen.GeneroTerceros)
            .HasForeignKey(ter => ter.IdGenero);

        builder.HasOne(terc => terc.Municipio)
            .WithMany(mun => mun.MunicipioTerceros)
            .HasForeignKey(ter => ter.IdMunicipio);

        builder.HasOne(ter => ter.Regimen)
            .WithMany(reg => reg.RegimenTerceros)
            .HasForeignKey(ter => ter.IdRegimen);

        builder.HasOne(ter => ter.TipoPersona)
            .WithMany(tPer => tPer.tipoPersonaTercero)
            .HasForeignKey(ter => ter.IdTippersona);

        builder.HasOne(ter => ter.Ciiu)
            .WithMany(ciiu => ciiu.CiiuTerceros)
            .HasForeignKey(ter => ter.IdCiiu);

        builder
            .Property(b => b.CreatedAt)
            .HasDefaultValueSql("DateTime.Now");


    }
}
