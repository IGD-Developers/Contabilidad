using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Ciius;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Ciius;

public class Consulta
{
    public class ListaCiius : IRequest<List<CiiuModel>> { }

    public class Manejador : IRequestHandler<ListaCiius, List<CiiuModel>>
    {
        private readonly CntContext _cntContext;
        private readonly IMapper _mapper;

        public Manejador(CntContext cntContext, IMapper mapper)
        {
            _cntContext = cntContext;
            _mapper = mapper;
        }

        public async Task<List<CiiuModel>> Handle(ListaCiius request, CancellationToken cancellationToken)
        {
            var listarCiius = await _cntContext.CntCiius
            .Include(x => x.CiiuSeccionCiiu)
            .Include(x => x.CiiuTipoCiiu)
            .ToListAsync();
            var listarciiusModel = _mapper.Map<List<CntCiiu>, List<CiiuModel>>(listarCiius);
            return listarciiusModel;
        }
    }

}