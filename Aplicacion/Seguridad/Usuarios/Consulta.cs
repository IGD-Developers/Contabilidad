
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dominio.Configuracion;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Seguridad;

public class Consulta
{

    //Lista de objetos tipo IRequest envolviendo una lista de tipo CnfUsuario
    public class ListaCnfUsuarios : IRequest<List<CnfUsuario>>
    {


    }


    //Clase Manejador que hereda de IRequestHandler. Obliga a implementar  Interfaz.
    // Requiere Constructor
    //Parametros: tipo de dato a devolver que es objeto IRequest ListaCntTipoComprobantes primera clase declarada,
    //el segundo pmt es el formato en que se devuelve que es un  List<CntTipoComprobante> 

    public class Manejador : IRequestHandler<ListaCnfUsuarios, List<CnfUsuario>>
    {

        private readonly CntContext _context;
        public Manejador(CntContext context)
        {
            _context = context;

        }

        //La interfaz se autogenera -agregamos async
        //La interfaz consume el objeto de EF para devolver la lista de tipo de comprobantes 

        public async Task<List<CnfUsuario>> Handle(ListaCnfUsuarios request, CancellationToken cancellationToken)
        {

            var usuarios = await _context.cnfUsuarios.ToListAsync();
            return usuarios;

        }
    }


}