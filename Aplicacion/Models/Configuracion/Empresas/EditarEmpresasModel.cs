namespace Aplicacion.Models.Configuracion.Empresas;

public class EditarEmpresasModel
{
    public int Id { get; set; }
    public string Nit { get; set; }
    public string RazonSocial { get; set; }
    public int? IdTerceroGerente { get; set; } 
}