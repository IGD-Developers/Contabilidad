using MediatR;
using Persistencia;
using System.Threading.Tasks;
using System.Threading;
using Dominio.Contabilidad;
using System;
using Aplicacion.Models.Contabilidad.Entidades;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Aplicacion.Contabilidad.Entidades;

public class ConsultaEntidadTipoImpuesto
{
    public class ConsultarEntidadTipoImpuesto : IdEntidadModel, IRequest<List<ListarEntidadesModel>>
    { }

    public class Manejador : IRequestHandler<ConsultarEntidadTipoImpuesto, List<ListarEntidadesModel>>
    {
        private CntContext _context;
        private readonly IMapper _mapper;



        public Manejador(CntContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ListarEntidadesModel>> Handle(ConsultarEntidadTipoImpuesto request, CancellationToken cancellationToken)
        {
            var entidadDto = await _context.cntEntidades
            .Include(t=>t.Tercero)
            .Include(i=>i.TipoImpuesto)
            .Where(i => i.IdTipoimpuesto == request.Id)
            .Select(p => _mapper.Map<CntEntidad, ListarEntidadesModel>(p))
            .ToListAsync();
            
            
             if (entidadDto == null) {
                throw new Exception("Tipo de Impuesto sin  Entidades ");
            };

            //var entidadDto = _mapper.Map<List<CntEntidad>,List<ListarEntidadesModel>>(entidades);
            
            return entidadDto;
        }
    }
}