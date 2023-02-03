using System.Threading.Tasks;
using Aplicacion.Models.Contabilidad.Consecutivos;
using Dominio.Contabilidad;

namespace Aplicacion.Contabilidad.Consecutivos;


public interface IInsertarConsecutivo
{

    /// <summary>
    /// Class <c>InsertarConsecutivo</c>
    /// <para >Recibe: ConsecutivoComprobanteModel={id_tipocomprobante,fecha,id_sucursal}
    ///</para>
    /// </summary>
    /// <returns> CntConsecutivo: El Consecutivo generado a partir del tipo de Incremento de cntTipoComprobante.
    /// En formato {id_tipocomprobante, co_ano,co_mes,co_consecutivo,id_sucursal}
    ///</returns>
    Task<CntConsecutivo> Insertar(ConsecutivoComprobanteModel model);
///TODO: MARIA No me funciona param
}