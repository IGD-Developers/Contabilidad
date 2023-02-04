using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.TipoCiius;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using MediatR;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.TipoCiius;

public class ConsultaId
{
    public class ConsultarId : IRequest<TipoCiiusModel>
    {
        public int Id;
    }

    public class Manejador : IRequestHandler<ConsultarId, TipoCiiusModel>
    {
        private readonly CntContext _context;
        private readonly IMapper _mapper;

        public Manejador(CntContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TipoCiiusModel> Handle(ConsultarId request, CancellationToken cancellationToken)
        {
            var consultaId = await _context.cntTipoCiius.FindAsync(request.Id);

            if (consultaId == null)
            {
                throw new Exception("TIPO CIIUS CONSULTADO NO EXISTE");
            }

            var consultaIdModel = _mapper.Map<CntTipoCiiu, TipoCiiusModel>(consultaId);

            return consultaIdModel;
        }
    }
}