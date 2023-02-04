using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Regimen;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Regimenes;

public class Consulta
{
    public class ListarRegimenes : IRequest<List<RegimenModel>> { }

    public class Manejador : IRequestHandler<ListarRegimenes, List<RegimenModel>>
    {
        public readonly CntContext _context;
        public readonly IMapper _mapper;

        public Manejador(CntContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<RegimenModel>> Handle(ListarRegimenes request, CancellationToken cancellationToken)
        {
            var listarRegimenes = await _context.CntRegimenes.ToListAsync();
            var listarRegimenesModel = _mapper.Map<List<CntRegimen>, List<RegimenModel>>(listarRegimenes);
            return listarRegimenesModel;
        }
    }
}