using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.Models.Contabilidad.Entidades;
using AutoMapper;
using Dominio.Contabilidad;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Contabilidad.Entidades
{
    public class Consulta
    {
        public class ListaCntEntidades : IRequest<List<ListarEntidadesModel>>
        {   }

        public class Manejador : IRequestHandler<ListaCntEntidades, List<ListarEntidadesModel>>
        {

             private CntContext _context;
             private readonly IMapper _mapper;



            public Manejador(CntContext context,IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<ListarEntidadesModel>> Handle(ListaCntEntidades request, CancellationToken cancellationToken)
            {
                //TODO: MARIA- Validar existe tercero, existe tipoimpuesto
                var entidades = await _context.cntEntidades
                .Include(t=>t.tercero)
                .Include(i=>i.tipoImpuesto)
                .ToListAsync();
                var entidadesDto = _mapper.Map<List<CntEntidad>,List<ListarEntidadesModel>>(entidades);
                
                return entidadesDto;
            }
        }

    }
}