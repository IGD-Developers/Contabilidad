using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.NotaAclaratoria;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.NotaAclaratorias;

public class ListaCntNotaAclaratoriasRequest : IRequest<List<ListarNotaAclaratoriaModel>>
{


}

//El manejador necesita dos parametros:
//la primera Clase de lista:  Formato en que lo vamos a devolver, tipo de dato
public class ListaCntNotaAclaratoriasHandler : IRequestHandler<ListaCntNotaAclaratoriasRequest, List<ListarNotaAclaratoriaModel>>
{

    private readonly CntContext _context;
    private readonly IMapper _mapper;

    public ListaCntNotaAclaratoriasHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ListarNotaAclaratoriaModel>> Handle(ListaCntNotaAclaratoriasRequest request, CancellationToken cancellationToken)
    {

        var notaAclaratorias = await _context.cntNotaAclaratorias
            .Include(t => t.NotaAclaratoriaTipo)
            .Include(p => p.CntPuct)
            .Where(n => n.Estado == "A")
            .ToListAsync();

        var notaAclaratoriasModel = _mapper.Map<List<CntNotaAclaratoria>, List<ListarNotaAclaratoriaModel>>(notaAclaratorias);

        return notaAclaratoriasModel;

    }
}