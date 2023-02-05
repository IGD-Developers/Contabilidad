namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Comprobantes;

/// <summary>
/// Interface 
/// <para >Recibe: data con la estructura InsertarComprobanteModel
///</para>
/// </summary>
/// <returns> IdComprobanteModel: El IdComprobanteModel.Id insertado en la tabla cnt_comprobantes
///</returns>

public interface IInsertarComprobante
{

    /// <summary>
    /// Interface 
    /// <para >Recibe: data con la estructura InsertarComprobanteModel
    ///</para>
    /// </summary>
    /// <returns> IdComprobanteModel: El IdComprobanteModel.Id insertado en la tabla cnt_comprobantes
    ///</returns>

    Task<IdComprobanteModel> Insertar(InsertarComprobantesModel model);

}