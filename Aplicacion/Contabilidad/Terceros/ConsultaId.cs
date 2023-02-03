using System;
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
    public class ConsultaId
    {
        public class TerceroId : IRequest<ListarTerceroModel>{
            public int Id;
        }

        public class Manejador : IRequestHandler<TerceroId, ListarTerceroModel> 
        {
            private readonly CntContext _context;
            private readonly IMapper _mapper;

            public Manejador(CntContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ListarTerceroModel> Handle(TerceroId request, CancellationToken cancellationToken)
            {
               var terceroId = await _context.CntTerceros
               .Include(g => g.genero)
               .Include(d => d.documentos)
               .Include(m => m.municipio).ThenInclude(z=>z.departamento)
               .Include(r => r.regimen)
               .Include(p => p.tipoPersona)
               .Include(c => c.ciiu).ThenInclude(z=>z.ciiuSeccionCiiu)
               .Include(c => c.ciiu).ThenInclude(z=>z.ciiuTipoCiiu)
               .Include(r => r.responsabilidadTerceros).ThenInclude(z=>z.Responsabilidad)
               .Include(e => e.entidadTerceros).ThenInclude(z=>z.tipoImpuesto)
               .FirstOrDefaultAsync(q => q.id == request.Id);

                if(terceroId==null){
                    throw new Exception("TERCERO CONSULTADO NO EXISTE");
                }

                var terceroIdModel = _mapper.Map<CntTercero, ListarTerceroModel>(terceroId);

                return terceroIdModel;
            }
        }


    }
}