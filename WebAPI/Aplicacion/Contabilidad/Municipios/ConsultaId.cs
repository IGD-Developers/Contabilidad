using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Municipios;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using MediatR;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Municipios;

public class ConsultaId
{
    public class ConsultarId : IRequest<MunicipioModel>
    {
        public int Id;
    }

    public class Manejador : IRequestHandler<ConsultarId, MunicipioModel>
    {
        private readonly CntContext _context;
        private readonly IMapper _mapper;

        public Manejador(CntContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MunicipioModel> Handle(ConsultarId request, CancellationToken cancellationToken)
        {
            var consultaId = await _context.CntMunucipios.FindAsync(request.Id);

            if (consultaId == null)
            {
                throw new Exception("Municipio Consultado no Existe");
            }

            var consultaIdModel = _mapper.Map<CntMunicipio, MunicipioModel>(consultaId);
            return consultaIdModel;
        }
    }

}