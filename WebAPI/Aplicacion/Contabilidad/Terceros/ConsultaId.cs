using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Tercero;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Terceros;

public class ConsultaId
{
    public class TerceroId : IRequest<ListarTerceroModel>
    {
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
            .Include(g => g.Genero)
            .Include(d => d.Documentos)
            .Include(m => m.Municipio).ThenInclude(z => z.Departamento)
            .Include(r => r.Regimen)
            .Include(p => p.TipoPersona)
            .Include(c => c.Ciiu).ThenInclude(z => z.CiiuSeccionCiiu)
            .Include(c => c.Ciiu).ThenInclude(z => z.CiiuTipoCiiu)
            .Include(r => r.ResponsabilidadTerceros).ThenInclude(z => z.Responsabilidad)
            .Include(e => e.EntidadTerceros).ThenInclude(z => z.TipoImpuesto)
            .FirstOrDefaultAsync(q => q.Id == request.Id);

            if (terceroId == null)
            {
                throw new Exception("TERCERO CONSULTADO NO EXISTE");
            }

            var terceroIdModel = _mapper.Map<CntTercero, ListarTerceroModel>(terceroId);

            return terceroIdModel;
        }
    }


}