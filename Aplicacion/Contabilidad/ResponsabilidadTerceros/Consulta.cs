using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.Models.Contabilidad.ResponsabilidadTercero;
using AutoMapper;
using Dominio.Contabilidad;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Contabilidad.ResponsabilidadTerceros
{
    public class Consulta
    {
        public class ListarResponsabilidades : IRequest<List<ResponsabilidadTerceroModel>>{}

        public class Manejador : IRequestHandler<ListarResponsabilidades, List<ResponsabilidadTerceroModel>>
        {
            private readonly CntContext _context;
            private readonly IMapper _mapper;

            public Manejador(CntContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<ResponsabilidadTerceroModel>> Handle(ListarResponsabilidades request, CancellationToken cancellationToken)
            {
                var listar = await _context.cntResponsabilidadTerceros
                .Include(r=>r.Responsabilidad)
                .ToListAsync();
                
                var ListarModel = _mapper.Map<List<CntResponsabilidadTer>, List<ResponsabilidadTerceroModel>>(listar);
                return ListarModel;
            }
        }
    }
}