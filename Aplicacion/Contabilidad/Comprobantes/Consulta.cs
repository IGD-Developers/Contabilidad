using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using Dominio.Contabilidad;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;
using AutoMapper;
using Aplicacion.Models.Contabilidad.Comprobantes;
using System.Linq;

namespace Aplicacion.Contabilidad.Comprobantes
{
    public class Consulta
    {
        public class ListaCntComprobantes : IRequest<List<ListarComprobantesModel>>
        {

        }

        public class Manejador : IRequestHandler<ListaCntComprobantes, List<ListarComprobantesModel>>
        {

            private readonly CntContext _context;
            private readonly IMapper _mapper;



            public Manejador(CntContext context,IMapper mapper)
            {
                _context = context;
                _mapper = mapper;



            }

            public async Task<List<ListarComprobantesModel>> Handle(ListaCntComprobantes request, CancellationToken cancellationToken)
            {
                // El contexto devuelve el dbset

            var comprobantes = await _context.cntComprobantes
            .Include(t => t.tipoComprobante)
            .ThenInclude(ctg => ctg.categoria)
            .Include(s => s.sucursal)
            .Include(u => u.usuario)
            .Include(d => d.comprobanteDetalleComprobantes)
            .ToListAsync();
          
            var comprobantesDto = _mapper.Map<List<CntComprobante>,List<ListarComprobantesModel>>(comprobantes);

            return comprobantesDto;

            }
        }

    }
}