using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.SeccionCiius;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using MediatR;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.SeccionCiius;

public class ConsultaId
{
    public class ConsultarId : IRequest<SeccionCiiusModel>
    {
        public int Id;
    }

    public class Manejador : IRequestHandler<ConsultarId, SeccionCiiusModel>
    {
        private readonly CntContext _context;
        private readonly IMapper _mapper;

        public Manejador(CntContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SeccionCiiusModel> Handle(ConsultarId request, CancellationToken cancellationToken)
        {
            var consultarId = await _context.CntSeccionCiius.FindAsync(request.Id);

            if (consultarId == null)
            {
                throw new Exception("SECCION CIIUS CONSULTADA NO EXISTE");
            }

            var consultarIdModel = _mapper.Map<CntSeccionCiiu, SeccionCiiusModel>(consultarId);
            return consultarIdModel;
        }
    }
}