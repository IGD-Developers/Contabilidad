using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.Models.Contabilidad.Bancos;
using AutoMapper;
using Dominio.Contabilidad;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Contabilidad.Bancos
{
    public class Consulta
    {

        public class ListaCntBancos : IRequest<List<ListarBancosModel>>
        {

        }

        public class Manejador : IRequestHandler<ListaCntBancos, List<ListarBancosModel>>
        {
            private CntContext _context;
            private readonly IMapper _mapper;

            public Manejador(CntContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<ListarBancosModel>> Handle(ListaCntBancos request, CancellationToken cancellationToken)
            {

                var entidades = await _context.cntBancos.ToListAsync();
                var entidadesDto = _mapper.Map<List<CntBanco>, List<ListarBancosModel>>(entidades);
                return entidadesDto;
            }
        }

    }
}