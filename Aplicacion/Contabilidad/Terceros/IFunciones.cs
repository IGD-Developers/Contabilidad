namespace Aplicacion.Contabilidad.Terceros;

public interface IFunciones
{    
    /// <summary>
    /// <c>CalcularDigitoVerificacion</c>
    /// Recibe como parametro el documento del tercero
    /// </summary>
    /// <returns> 
    /// Retorna el digito de verificaciín
    ///</returns>
    /// <param name="Nit">Documento del tercero
    ///</param>
    string CalcularDigitoVerificacion(string Nit);


}