using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Genero;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using MediatR;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Generos;

public class ConsultaId
{
    public class ConsultarId : IRequest<GeneroModel>
    {
        public int Id;
    }

    public class Manejador : IRequestHandler<ConsultarId, GeneroModel>
    {
        private readonly CntContext _context;
        private readonly IMapper _mapper;

        public Manejador(CntContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GeneroModel> Handle(ConsultarId request, CancellationToken cancellationToken)
        {
            var generoId = await _context.CntGeneros.FindAsync(request.Id);

            if (generoId == null)
            {
                throw new Exception("Genero Consultado no Existe");
            }

            var generoIdModel = _mapper.Map<CntGenero, GeneroModel>(generoId);

            return generoIdModel;
        }
    }
}