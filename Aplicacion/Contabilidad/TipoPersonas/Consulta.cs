using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.Models.Contabilidad.TipoPersona;
using AutoMapper;
using Dominio.Contabilidad;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Contabilidad.TipoPersonas;

public class Consulta
{
    public class ListarTipoPersonas : IRequest<List<TipoPersonaModel>>{}

    public class Manejador : IRequestHandler<ListarTipoPersonas, List<TipoPersonaModel>>
    {
        private readonly CntContext _context;
        private readonly IMapper _mapper;
        
        public Manejador(CntContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TipoPersonaModel>> Handle(ListarTipoPersonas request, CancellationToken cancellationToken)
        {
            var listaTipoPersonas = await _context.CntTipoPersonas.ToListAsync();

            var tipoPersonasModel = _mapper.Map<List<CntTipoPersona>, List<TipoPersonaModel>>(listaTipoPersonas);
            
            return tipoPersonasModel;
        }
    }
}