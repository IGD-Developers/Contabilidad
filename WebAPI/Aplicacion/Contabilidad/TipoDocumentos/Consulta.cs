using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.TipoDocumento;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.TipoDocumentos;

//Clase que representa lista de elementos a retornar desde la db
public class ListaTipoDocumentosRequest : IRequest<List<TipoDocumentoModel>> { }

//Clase para manejar la logica de la operacion
//(que va a devolver, formato)
public class ListaTipoDocumentosHandler : IRequestHandler<ListaTipoDocumentosRequest, List<TipoDocumentoModel>>
{
    private readonly CntContext _context;
    private readonly IMapper _mapper;
    public ListaTipoDocumentosHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<TipoDocumentoModel>> Handle(ListaTipoDocumentosRequest request, CancellationToken cancellationToken)
    {
        var tipoDocumento = await _context.CntTipoDocumentos.ToListAsync();

        var tipodocumentoModel = _mapper.Map<List<CntTipoDocumento>, List<TipoDocumentoModel>>(tipoDocumento);

        return tipodocumentoModel;
    }
}