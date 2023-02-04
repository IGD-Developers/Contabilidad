namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Terceros;

public interface IFunciones
{
    /// <summary>
    /// <c>CalcularDigitoVerificacion</c>
    /// Recibe como parametro el documento del Tercero
    /// </summary>
    /// <returns> 
    /// Retorna el digito de verificaciín
    ///</returns>
    /// <param name="Nit">Documento del Tercero
    ///</param>
    string CalcularDigitoVerificacion(string Nit);


}