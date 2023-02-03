using Dominio.Contabilidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Mapeo.Contabilidad
{
    public class TerceroMap : IEntityTypeConfiguration<CntTercero>
    {
        public void Configure(EntityTypeBuilder<CntTercero> builder)
        {
                builder.ToTable("cnt_tercero")
                    .HasKey( pk => pk.id);
                                   
                builder.HasOne(terc => terc.documentos)
                    .WithMany(tDoc => tDoc.documentoTerceros)
                    .HasForeignKey(ter => ter.id_tipodocumento);

                builder.HasOne(terc => terc.genero)
                    .WithMany(gen => gen.generoTerceros)
                    .HasForeignKey(ter => ter.id_genero);
                
                builder.HasOne<CntMunicipio>(terc => terc.municipio)
                    .WithMany(mun => mun.municipioTerceros)
                    .HasForeignKey(ter => ter.id_municipio);

                builder.HasOne<CntRegimen>(ter => ter.regimen)
                    .WithMany(reg => reg.regimenTerceros)
                    .HasForeignKey(ter => ter.id_regimen);

                builder.HasOne<CntTipoPersona>(ter => ter.tipoPersona)
                    .WithMany(tPer => tPer.tipoPersonaTercero)
                    .HasForeignKey(ter => ter.id_tippersona);

                builder.HasOne<CntCiiu>(ter => ter.ciiu)
                    .WithMany(ciiu => ciiu.ciiuTerceros)
                    .HasForeignKey(ter => ter.id_ciiu);  

                builder
                    .Property(b => b.created_at)
                    .HasDefaultValueSql("DateTime.Now");             

                
        }
    }
} 