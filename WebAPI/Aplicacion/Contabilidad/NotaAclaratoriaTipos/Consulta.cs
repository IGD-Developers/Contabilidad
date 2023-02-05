using System.Collections.Generic;
using System.Threading;
using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ContabilidadWebAPI.Persistencia;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.NotaAclaratoriaTipo;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.NotaAclaratoriaTipos;

public class ListaCntNotaAclaratoriaTiposRequest : IRequest<List<NotaAclaratoriaTipoModel>>
{ }

public class ListaCntNotaAclaratoriaTiposHandler : IRequestHandler<ListaCntNotaAclaratoriaTiposRequest, List<NotaAclaratoriaTipoModel>>
{
    private CntContext _context;
    private IMapper _mapper;

    public ListaCntNotaAclaratoriaTiposHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<NotaAclaratoriaTipoModel>> Handle(ListaCntNotaAclaratoriaTiposRequest request, CancellationToken cancellationToken)
    {
        var notaAclaratoriaTipos = await _context.cntNotaAclaratoriaTipos.ToListAsync();

        var notaAclaratoriasTiposModel = _mapper.Map<List<CntNotaAclaratoriaTipo>, List<NotaAclaratoriaTipoModel>>(notaAclaratoriaTipos);

        return notaAclaratoriasTiposModel;

    }
}