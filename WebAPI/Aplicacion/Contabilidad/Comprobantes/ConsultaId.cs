using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ContabilidadWebAPI.Persistencia;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Comprobantes;
using ContabilidadWebAPI.Dominio.Contabilidad;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Comprobantes;

public class ConsultarComprobanteRequest : IdComprobanteModel, IRequest<ListarComprobantesModel>
{ }

public class ConsultarComprobanteHandler : IRequestHandler<ConsultarComprobanteRequest, ListarComprobantesModel>
{

    private readonly CntContext context;
    private readonly IMapper _mapper;


    public ConsultarComprobanteHandler(CntContext context, IMapper mapper)
    {
        this.context = context;
        _mapper = mapper;
    }

    public async Task<ListarComprobantesModel> Handle(ConsultarComprobanteRequest request, CancellationToken cancellationToken)
    {
        // var Comprobante = await context.cntComprobantes.FindAsync(request.Id);
        // if (Comprobante == null) {
        //     throw new Exception("Registro no encontrado");
        // };              
        // return Comprobante;

        var Comprobante = await context.cntComprobantes
        .Include(t => t.TipoComprobante)
        .ThenInclude(ctg => ctg.Categoria)
        .Include(s => s.Sucursal)
        .Include(u => u.Usuario)
        .Include(d => d.ComprobanteDetalleComprobantes)
        .FirstOrDefaultAsync(cmp => cmp.Id == request.Id);
        // Nota:la condicion del FirstOrDefaultAsync puede ir en un Where(cmp => cmp.Id == request.Id) 

        if (Comprobante == null)
        {
            throw new Exception("Registro no encontrado");
        };
        var comprobanteDto = _mapper.Map<CntComprobante, ListarComprobantesModel>(Comprobante);
        return comprobanteDto;

    }
}