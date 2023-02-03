using System;
using System.Collections.Generic;
using Dominio.Configuracion;

namespace Dominio.Contabilidad;

public class CntTipoComprobante
{
    public int id { get; set; }
    public int id_categoriacomprobante { get; set; }
    public string codigo { get; set; }
    public string nombre { get; set; }
    public string tco_incremento { get; set; }
    public DateTime? created_at { get; set; }
    public DateTime? updated_at { get; set; }
    public string editable { get; set; }
    public string anulable { get; set; }
    public string borrable { get; set; }
    public string id_usuario { get; set; }

    public ICollection<CntComprobante> ComprobantesTipoComprobante { get; set; }

    public CnfUsuario usuario { get; set; }

    public CntCategoriaComprobante categoria { get; set; }
    public ICollection<CntConsecutivo> tipoComprobanteConsecutivos { get; set; }





}