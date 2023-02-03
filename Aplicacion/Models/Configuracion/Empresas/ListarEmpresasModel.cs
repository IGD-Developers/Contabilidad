using Dominio.Configuracion;
using Dominio.Contabilidad;

namespace Aplicacion.Models.Configuracion.Empresas;

public class ListarEmpresasModel
{
    public int Id { get; set; }
    public string Nit { get; set; }
    public string RazonSocial { get; set; }
    public int? IdTerceroGerente { get; set; }

    public GerenteEmpresaModel NombreGerente { get; set; }
   
    public string TerceroEmpresaterRazonsocial { get; set; }
   // Lo anterior fue para probar porque en la teoría de Automapper si empieza por el Nombre de la propiedad de navegacion debe reconocerlo   
}