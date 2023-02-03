using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.Models.Contabilidad.Tercero;
using AutoMapper;
using Dominio.Contabilidad;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Contabilidad.Terceros
{
    public class Consulta
    {
        public class ListarTerceros : IRequest<List<ListarTerceroModel>>{}

        public class Manejador : IRequestHandler<ListarTerceros, List<ListarTerceroModel>>
        {
            private readonly CntContext _context;
            private readonly IMapper _mapper;

            public Manejador(CntContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<ListarTerceroModel>> Handle(ListarTerceros request, CancellationToken cancellationToken)
            {
               var terceros = await _context.CntTerceros
               .Include(g => g.genero)
               .Include(d => d.documentos)
               .Include(m => m.municipio).ThenInclude(z=>z.departamento)
               .Include(r => r.regimen)
               .Include(p => p.tipoPersona)
               .Include(c => c.ciiu).ThenInclude(z=>z.ciiuSeccionCiiu)
               .Include(c => c.ciiu).ThenInclude(z=>z.ciiuTipoCiiu)
               .Include(r => r.responsabilidadTerceros).ThenInclude(z=>z.Responsabilidad)
               .Include(e => e.entidadTerceros).ThenInclude(z=>z.tipoImpuesto)
               .ToListAsync();

               var tercerosModel = _mapper.Map<List<CntTercero>, List<ListarTerceroModel>>(terceros);

               
               return tercerosModel;
            }
        }
    }
}