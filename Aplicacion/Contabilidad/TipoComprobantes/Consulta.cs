using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.Models.Contabilidad.TipoComprobantes;
using AutoMapper;
//using Dominio;
using Dominio.Contabilidad;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Contabilidad.TipoComprobantes
{
    public class Consulta
    {
        //Lista de objetos tipo IRequest envolviendo una lista de tipo CntTipoComprobante
        public class ListaCntTipoComprobantes : IRequest<List<ListarTipoComprobanteModel>>
        {

        }


        //Clase Manejador que hereda de IRequestHandler. Obliga a implementar  Interfaz.
        // Requiere Constructor
        //Parametros: tipo de dato a devolver que es objeto IRequest ListaCntTipoComprobantes primera Clase declarada,
        //el segundo pmt es el formato en que se devuelve que es un  List<CntTipoComprobante> 
        public class Manejador : IRequestHandler<ListaCntTipoComprobantes, List<ListarTipoComprobanteModel>>
        {

            private CntContext _context;
            private readonly IMapper _mapper;



            public Manejador(CntContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;


            }
            //La interfaz se autogenera -agregamos async
            //La interfaz consume el objeto de EF para devolver la lista de tipo de comprobantes 

            public async Task<List<ListarTipoComprobanteModel>> Handle(ListaCntTipoComprobantes request, CancellationToken cancellationToken)
            {
                // El contexto devuelve desde el dbset
                var entidades = await _context.cntTipoComprobantes
                .Include(t => t.Categoria)
                .ToListAsync();

                var entidadesDto = _mapper.Map<List<CntTipoComprobante>, List<ListarTipoComprobanteModel>>(entidades);

                return entidadesDto;

            }
        }

    }
}