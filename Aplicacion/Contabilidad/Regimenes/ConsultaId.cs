using System;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.Models.Contabilidad.Regimen;
using AutoMapper;
using Dominio.Contabilidad;
using MediatR;
using Persistencia;

namespace Aplicacion.Contabilidad.Regimenes
{
    public class ConsultaId
    {
        public class ConsultarId : IRequest<RegimenModel>{
            public int Id;
        }

        public class Manejador : IRequestHandler<ConsultarId, RegimenModel>
        {
            private readonly CntContext _context;
            private readonly IMapper _mapper;

            public Manejador(CntContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<RegimenModel> Handle(ConsultarId request, CancellationToken cancellationToken)
            {
                var consultaId = await _context.CntRegimenes.FindAsync(request.Id);

                if(consultaId==null){
                    throw new Exception("Regimen Consultado no Existe");
                }

                var consultaIdModel = _mapper.Map<CntRegimen, RegimenModel>(consultaId);
                return consultaIdModel;
            }
        }
    }
}