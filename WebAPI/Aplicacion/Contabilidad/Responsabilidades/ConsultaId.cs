using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Responsabilidad;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using MediatR;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Responsabilidades;

public class ConsultaId
{
    public class ConsultarId : IRequest<ResponsabilidadModel>
    {
        public int Id;
    }

    public class Manejador : IRequestHandler<ConsultarId, ResponsabilidadModel>
    {
        private readonly CntContext _context;
        private readonly IMapper _mapper;

        public Manejador(CntContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponsabilidadModel> Handle(ConsultarId request, CancellationToken cancellationToken)
        {
            var consultarId = await _context.cntResponsabilidades.FindAsync(request.Id);

            if (consultarId == null)
            {
                throw new Exception("Responsabilidad Consultada no existe");
            }

            var consultarIdModel = _mapper.Map<CntResponsabilidad, ResponsabilidadModel>(consultarId);
            return consultarIdModel;
        }
    }
}