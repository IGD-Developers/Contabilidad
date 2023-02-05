using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.TipoComprobantes;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.TipoComprobantes;


public class ConsultarTipoComprobanteRequest : IdModel, IRequest<ListarTipoComprobanteModel>
{ }
public class ConsultarTipoComprobanteHandler : IRequestHandler<ConsultarTipoComprobanteRequest, ListarTipoComprobanteModel>
{
    private CntContext _context;
    private readonly IMapper _mapper;



    public ConsultarTipoComprobanteHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ListarTipoComprobanteModel> Handle(ConsultarTipoComprobanteRequest request, CancellationToken cancellationToken)
    {
        var entidad = await _context.cntTipoComprobantes
        .Include(t => t.Categoria)
        .SingleOrDefaultAsync(i => i.Id == request.Id);

        if (entidad == null)
        {
            throw new Exception("Registro no encontrado");
        };
        var entidadDto = _mapper.Map<CntTipoComprobante, ListarTipoComprobanteModel>(entidad);

        return entidadDto;
    }
}