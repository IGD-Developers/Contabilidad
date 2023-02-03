using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.Models.Contabilidad.TipoCiius;
using AutoMapper;
using Dominio.Contabilidad;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Contabilidad.TipoCiius;

public class Consulta
{
    public class ListarTipoCiius : IRequest<List<TipoCiiusModel>>{}

    public class Manejador : IRequestHandler<ListarTipoCiius, List<TipoCiiusModel>>
    {
        private readonly CntContext _context;
        private readonly IMapper _mapper;

        public Manejador(CntContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TipoCiiusModel>> Handle(ListarTipoCiius request, CancellationToken cancellationToken)
        {
            var listaTipoCiius = await _context.cntTipoCiius.ToListAsync();

            var listaTipoCiiusModel = _mapper.Map<List<CntTipoCiiu>,List<TipoCiiusModel>>(listaTipoCiius);
            
            return listaTipoCiiusModel;
        }
    }

}