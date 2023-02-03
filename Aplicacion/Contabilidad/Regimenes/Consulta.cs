using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.Models.Contabilidad.Regimen;
using AutoMapper;
using Dominio.Contabilidad;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Contabilidad.Regimenes;

public class Consulta
{
    public class ListarRegimenes : IRequest<List<RegimenModel>>{}

    public class Manejador : IRequestHandler<ListarRegimenes, List<RegimenModel>>
    {
        public readonly CntContext _context;
        public readonly IMapper _mapper;

        public Manejador(CntContext context,IMapper mapper)
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