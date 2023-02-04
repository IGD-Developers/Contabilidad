using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.CentroCostos;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.CentroCostos;

public class Consulta
{

    public class ListaCntCentroCostos : IRequest<List<ListarCentroCostosModel>>
    {


    }

    public class Manejador : IRequestHandler<ListaCntCentroCostos, List<ListarCentroCostosModel>>
    {
        private CntContext _context;
        private readonly IMapper _mapper;



        public Manejador(CntContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ListarCentroCostosModel>> Handle(ListaCntCentroCostos request, CancellationToken cancellationToken)
        {

            var entidades = await _context.cntCentroCostos.ToListAsync();
            var entidadesDto = _mapper.Map<List<CntCentroCosto>, List<ListarCentroCostosModel>>(entidades);
            return entidadesDto;
        }
    }


}