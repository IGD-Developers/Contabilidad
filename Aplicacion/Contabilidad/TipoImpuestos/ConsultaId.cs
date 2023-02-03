using MediatR;
using Persistencia;
using System.Threading.Tasks;
using System.Threading;
using Dominio.Contabilidad;
using System;
using Aplicacion.Models.Contabilidad.TipoImpuestos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Contabilidad.TipoImpuestos
{
    public class ConsultaId
    {
        public class ConsultarId : IdModel,IRequest<ListarTipoImpuestosModel>
        { }

        public class Manejador : IRequestHandler<ConsultarId, ListarTipoImpuestosModel>
        {
           private CntContext _context;

            private readonly IMapper _mapper;



            public Manejador(CntContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ListarTipoImpuestosModel> Handle(ConsultarId request, CancellationToken cancellationToken)
            {


                var entidad = await _context.cntTipoImpuestos
                .SingleOrDefaultAsync(i => i.id == request.Id);

                if (entidad == null)
                {
                    throw new Exception("Registro no encontrado");
                };
                var entidadDto = _mapper.Map<CntTipoImpuesto, ListarTipoImpuestosModel>(entidad);
                return entidadDto;


               

            }

        }

    }
}