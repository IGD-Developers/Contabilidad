using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Tercero;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Terceros;

public class Consulta
{
    public class ListarTerceros : IRequest<List<ListarTerceroModel>> { }

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
            .Include(g => g.Genero)
            .Include(d => d.Documentos)
            .Include(m => m.Municipio).ThenInclude(z => z.Departamento)
            .Include(r => r.Regimen)
            .Include(p => p.TipoPersona)
            .Include(c => c.Ciiu).ThenInclude(z => z.CiiuSeccionCiiu)
            .Include(c => c.Ciiu).ThenInclude(z => z.CiiuTipoCiiu)
            .Include(r => r.ResponsabilidadTerceros).ThenInclude(z => z.Responsabilidad)
            .Include(e => e.EntidadTerceros).ThenInclude(z => z.TipoImpuesto)
            .ToListAsync();

            var tercerosModel = _mapper.Map<List<CntTercero>, List<ListarTerceroModel>>(terceros);


            return tercerosModel;
        }
    }
}