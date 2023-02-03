
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.Models.Contabilidad.CategoriaComprobantes;
using AutoMapper;
using Dominio.Contabilidad;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Contabilidad.CategoriaComprobantes
{
    public class Consulta
    {

        //Lista de objetos tipo IRequest envolviendo una lista de tipo CntCategoriaComprobante
        public class ListaCntCategoriaComprobantes : IRequest<List<ListarCategoriaComprobantesModel>>
        {
        }


        //Parametros: tipo de dato a devolver que es objeto IRequest ListaCntTipoComprobantes primera Clase declarada,
        //el segundo pmt es el formato en que se devuelve que es un  List<CntTipoComprobante>
        //Obliga a implementar  Interfaz.
        // Requiere Constructor
        public class Manejador : IRequestHandler<ListaCntCategoriaComprobantes, List<ListarCategoriaComprobantesModel>>
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
            public async Task<List<ListarCategoriaComprobantesModel>> Handle(ListaCntCategoriaComprobantes request, CancellationToken cancellationToken)
            {
                // El contexto devuelve desde el dbset

                var entidades = await _context.cntCategoriaComprobantes
                .Include(c => c.CategoriaTipoComprobantes)
                .ToListAsync();

                var entidadesDto = _mapper.Map<List<CntCategoriaComprobante>, List<ListarCategoriaComprobantesModel>>(entidades);

                return entidadesDto;

            }
        }

    }
}