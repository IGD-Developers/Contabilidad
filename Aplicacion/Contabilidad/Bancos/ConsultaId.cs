using MediatR;
using Persistencia;
using System.Threading.Tasks;
using System.Threading;
using Dominio.Contabilidad;
using System;
using Aplicacion.Models.Contabilidad.Bancos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Contabilidad.Bancos
{
    public class ConsultaId
    {
        public class ConsultarId : IdBancoModel,IRequest<ListarBancosModel>
        { }

        public class Manejador : IRequestHandler<ConsultarId, ListarBancosModel>
        {
            private CntContext _context;

            private readonly IMapper _mapper;



            public Manejador(CntContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ListarBancosModel> Handle(ConsultarId request, CancellationToken cancellationToken)
            {


                var entidad = await _context.cntBancos
                .SingleOrDefaultAsync(i => i.id == request.Id);

                if (entidad == null)
                {
                    throw new Exception("Registro no encontrado");
                };
                var entidadDto = _mapper.Map<CntBanco, ListarBancosModel>(entidad);
                return entidadDto;
                
                
            }
        }

    }
}