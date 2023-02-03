using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.Models.Contabilidad.Responsabilidad;
using AutoMapper;
using Dominio.Contabilidad;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Contabilidad.Responsabilidades;

public class Consulta
{
    public class ListarResponsabilidades : IRequest<List<ResponsabilidadModel>>{}

    public class Manejador : IRequestHandler<ListarResponsabilidades, List<ResponsabilidadModel>>
    {
        private readonly CntContext _context;
        private readonly IMapper _mapper;

        public Manejador(CntContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ResponsabilidadModel>> Handle(ListarResponsabilidades request, CancellationToken cancellationToken)
        {
            var responsabilidades = await _context.cntResponsabilidades.ToListAsync();
            var responsabilidadesModel = _mapper.Map<List<CntResponsabilidad>, List<ResponsabilidadModel>>(responsabilidades);

            return responsabilidadesModel;
        }

      
    }
}