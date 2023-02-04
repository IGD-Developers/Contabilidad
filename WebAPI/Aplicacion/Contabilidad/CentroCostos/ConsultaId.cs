using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using AutoMapper;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.CentroCostos;
using ContabilidadWebAPI.Persistencia;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.CentroCostos;

public class ConsultaId
{
    public class ConsultaPorId : IdCentroCostoModel, IRequest<ListarCentroCostosModel>
    { }


    public class Manejador : IRequestHandler<ConsultaPorId, ListarCentroCostosModel>
    {

        private CntContext _context;
        private readonly IMapper _mapper;



        public Manejador(CntContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ListarCentroCostosModel> Handle(ConsultaPorId request, CancellationToken cancellationToken)
        {
            var entidad = await _context.cntCentroCostos.FindAsync(request.Id);
            if (entidad == null)
            {
                throw new Exception("Registro no encontrado");
            };
            var entidadDto = _mapper.Map<CntCentroCosto, ListarCentroCostosModel>(entidad);
            return entidadDto;
        }
    }
}