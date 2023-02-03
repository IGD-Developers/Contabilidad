using System;

namespace Aplicacion.Models.Contabilidad.LiquidaImpuestos;

public class ListarLiquidaImpuestosModel
{
    public int Id { get; set; }
    public int IdTipoimpuesto { get; set; }
    public int IdComprobante { get; set; }
    public int IdPuc { get; set; }
    public int IdTercero { get; set; }
    //public DateTime LimFecha { get; set; }
    public DateTime LimFechainicial { get; set; }
    public DateTime LimFechafinal { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string NombreUsuario { get; set; }
    
    public LiquidaTipoImpuestoModel TipoImpuesto { get; set; }
    public LiquidaImpuestoTerceroModel Tercero { get; set; }

    // public CntPucModel puc { get; set; }

    public ImpuestoComprobanteModel Comprobante { get; set; }

    // public CnfUsuarioModel Usuario { get; set; }
}