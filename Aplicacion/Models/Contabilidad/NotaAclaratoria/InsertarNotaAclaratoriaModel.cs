using System;

namespace Aplicacion.Models.Contabilidad.NotaAclaratoria;

public class InsertarNotaAclaratoriaModel
{
    public int NacConsecutivo { get; set; }
    public DateTime NacFecha { get; set; }
    public int? IdPuc { get; set; }
    public int IdNotaaclaratoriatipo { get; set; }
    public string NacTitulo { get; set; }
    public string NacDetalle { get; set; }
    public string IdUsuario { get; set; }       
}