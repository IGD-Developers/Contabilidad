namespace ContabilidadWebAPI.Aplicacion.Seguridad.Usuarios;

//Lista de objetos tipo IRequest envolviendo una lista de tipo CnfUsuario
public class ListaCnfUsuariosRequest : IRequest<List<CnfUsuario>>
{


}


//Clase Manejador que hereda de IRequestHandler. Obliga a implementar  Interfaz.
// Requiere Constructor
//Parametros: tipo de dato a devolver que es objeto IRequest ListaCntTipoComprobantes primera Clase declarada,
//el segundo pmt es el formato en que se devuelve que es un  List<CntTipoComprobante> 

public class ListaCnfUsuariosHandler : IRequestHandler<ListaCnfUsuariosRequest, List<CnfUsuario>>
{

    private readonly CntContext _context;
    public ListaCnfUsuariosHandler(CntContext context)
    {
        _context = context;

    }

    //La interfaz se autogenera -agregamos async
    //La interfaz consume el objeto de EF para devolver la lista de tipo de comprobantes 

    public async Task<List<CnfUsuario>> Handle(ListaCnfUsuariosRequest request, CancellationToken cancellationToken)
    {

        var usuarios = await _context.cnfUsuarios.ToListAsync();
        return usuarios;

    }
}