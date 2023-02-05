namespace ContabilidadWebAPI.Dominio.Contabilidad;

public class CntMunicipio
{
    public int Id { get; set; }
    public int IdDepartamento { get; set; }
    public string Codigo { get; set; }
    public string Nombre { get; set; }

    public CntDepartamento Departamento { get; set; }
    public ICollection<CntTercero> MunicipioTerceros { get; set; }

}