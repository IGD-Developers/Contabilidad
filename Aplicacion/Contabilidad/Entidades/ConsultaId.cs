using MediatR;
using Persistencia;
using System.Threading.Tasks;
using System.Threading;
using Dominio.Contabilidad;
using System;
using Aplicacion.Models.Contabilidad.Entidades;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Contabilidad.Entidades;

public class ConsultaId
{
    public class ConsultarId : IdEntidadModel,IRequest<ListarEntidadesModel>
    {  }

    public class Manejador : IRequestHandler<ConsultarId, ListarEntidadesModel>
    {
        private CntContext _context;
         private readonly IMapper _mapper;



        public Manejador(CntContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ListarEntidadesModel> Handle(ConsultarId request, CancellationToken cancellationToken)
        {
            
            var entidad = await _context.cntEntidades
            .Include(t=>t.tercero)
            .Include(i=>i.tipoImpuesto)
            .SingleOrDefaultAsync(i => i.id == request.Id);
            
            
             if (entidad == null) {
                throw new Exception("Registro no encontrado");
            };

            var entidadDto = _mapper.Map<CntEntidad,ListarEntidadesModel>(entidad);
            
            return entidadDto;
        }
    }

}