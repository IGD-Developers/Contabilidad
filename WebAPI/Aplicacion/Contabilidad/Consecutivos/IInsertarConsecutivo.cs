using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Consecutivos;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Consecutivos;


public interface IInsertarConsecutivo
{

    /// <summary>
    /// Class <c>InsertarConsecutivo</c>
    /// <para >Recibe: ConsecutivoComprobanteModel={IdTipocomprobante,Fecha,IdSucursal}
    ///</para>
    /// </summary>
    /// <returns> CntConsecutivo: El Consecutivo generado a partir del tipo de Incremento de cntTipoComprobante.
    /// En formato {IdTipocomprobante, CoAno,CoMes,CoConsecutivo,IdSucursal}
    ///</returns>
    Task<CntConsecutivo> Insertar(ConsecutivoComprobanteModel model);
    ///TODO: MARIA No me funciona param
}