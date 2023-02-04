using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.TipoPersona;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.TipoPersonas;

public class Consulta
{
    public class ListarTipoPersonas : IRequest<List<TipoPersonaModel>> { }

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