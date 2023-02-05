using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.CuentaImpuestos;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.CuentaImpuestos;

public class ListaCntCuentaImpuestosRequest : IRequest<List<ListarCuentaImpuestosModel>>
{ }

public class ListaCntCuentaImpuestosHandler : IRequestHandler<ListaCntCuentaImpuestosRequest, List<ListarCuentaImpuestosModel>>
{


    private readonly CntContext _context;
    private readonly IMapper _mapper;
    public ListaCntCuentaImpuestosHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ListarCuentaImpuestosModel>> Handle(ListaCntCuentaImpuestosRequest request, CancellationToken cancellationToken)
    {

        var entidadesDto1 = await _context.cntCuentaImpuestos
                            .Include(p => p.Puc)
                            .Include(p => p.TipoImpuesto)
                            .Select(p => _mapper.Map<CntCuentaImpuesto, ListarCuentaImpuestosModel>(p))
                            .ToListAsync();

        return entidadesDto1;

        // var entidades = await _context.cntCuentaImpuestos
        //                     .Include(p => p.puc)
        //                     .Include(ti => ti.TipoImpuesto)
        //                     .ToListAsync();
        // //var entidadesDto = _mapper.Map<List<CntCuentaImpuesto>, List<ListarCuentaImpuestosModel>>(entidades);


        // var entidades1 = await _context.cntCuentaImpuestos
        //                     .Include(p => p.puc)
        //                     .Include(p => p.TipoImpuesto)
        //                     .Select(p =>new  ListarCuentaImpuestosModel()
        //                     {
        //                         PucNombre =p.puc.Nombre,
        //                         PucCodigo =p.puc.Codigo,
        //                         TipoImpuestoNombre=p.TipoImpuesto.Nombre,
        //                         TipoImpuestoCodigo=p.TipoImpuesto.Codigo
        //                     })
        //                     .ToListAsync();


    }
}
