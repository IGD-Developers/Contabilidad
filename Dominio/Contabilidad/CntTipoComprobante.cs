using System;
using System.Collections.Generic;
using Dominio.Configuracion;

namespace Dominio.Contabilidad;

public class CntTipoComprobante
{
    public int Id { get; set; }
    public int IdCategoriacomprobante { get; set; }
    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public string TcoIncremento { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string Editable { get; set; }
    public string Anulable { get; set; }
    public string Borrable { get; set; }
    public string IdUsuario { get; set; }

    public ICollection<CntComprobante> ComprobantesTipoComprobante { get; set; }

    public CnfUsuario Usuario { get; set; }

    public CntCategoriaComprobante Categoria { get; set; }
    public ICollection<CntConsecutivo> TipoComprobanteConsecutivos { get; set; }
}