
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.Models.Contabilidad.TipoImpuestos;
using AutoMapper;
using Dominio.Contabilidad;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;


namespace Aplicacion.Contabilidad.TipoImpuestos;

public class Consulta
{

    public class ListaCntTipoImpuestos : IRequest<List<ListarTipoImpuestosModel>>
    {  }

    public class Manejador : IRequestHandler<ListaCntTipoImpuestos, List<ListarTipoImpuestosModel>>
    {
        private readonly CntContext _context;
        private readonly IMapper _mapper;
        public Manejador(CntContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ListarTipoImpuestosModel>> Handle(ListaCntTipoImpuestos request, CancellationToken cancellationToken)
        {

             var entidades = await _context.cntTipoImpuestos.ToListAsync();
            var entidadesDto = _mapper.Map<List<CntTipoImpuesto>, List<ListarTipoImpuestosModel>>(entidades);
            return entidadesDto;

           
        }
    }
}