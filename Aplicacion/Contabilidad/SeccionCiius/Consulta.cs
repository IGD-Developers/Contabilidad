using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.Models.Contabilidad.SeccionCiius;
using AutoMapper;
using Dominio.Contabilidad;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Contabilidad.SeccionCiius
{
    public class Consulta
    {
        public class ListarSeccionCiius : IRequest<List<SeccionCiiusModel>>{}

        public class Manejador : IRequestHandler<ListarSeccionCiius, List<SeccionCiiusModel>>
        {
            private readonly CntContext _context;
            private readonly IMapper _mapper;

            public Manejador(CntContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<SeccionCiiusModel>> Handle(ListarSeccionCiius request, CancellationToken cancellationToken)
            {
                var listarSeccionCiius = await _context.CntSeccionCiius.ToListAsync();

                var listarSeccionCiiusModel = _mapper.Map<List<CntSeccionCiiu>, List<SeccionCiiusModel>>(listarSeccionCiius);
                
                return listarSeccionCiiusModel;
            }
        }
    }
}