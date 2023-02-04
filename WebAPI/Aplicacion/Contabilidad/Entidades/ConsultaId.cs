using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Entidades;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Entidades;

public class ConsultaId
{
    public class ConsultarId : IdEntidadModel, IRequest<ListarEntidadesModel>
    { }

    public class Manejador : IRequestHandler<ConsultarId, ListarEntidadesModel>
    {
        private CntContext _context;
        private readonly IMapper _mapper;



        public Manejador(CntContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ListarEntidadesModel> Handle(ConsultarId request, CancellationToken cancellationToken)
        {

            var entidad = await _context.cntEntidades
            .Include(t => t.Tercero)
            .Include(i => i.TipoImpuesto)
            .SingleOrDefaultAsync(i => i.Id == request.Id);


            if (entidad == null)
            {
                throw new Exception("Registro no encontrado");
            };

            var entidadDto = _mapper.Map<CntEntidad, ListarEntidadesModel>(entidad);

            return entidadDto;
        }
    }

}