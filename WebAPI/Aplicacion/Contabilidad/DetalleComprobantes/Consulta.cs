namespace ContabilidadWebAPI.Aplicacion.Contabilidad.DetalleComprobantes;

public class ListaDetalleComprobantesRequest : IRequest<List<CntDetalleComprobante>>
{


}

public class ListaDetalleComprobantesHandler : IRequestHandler<ListaDetalleComprobantesRequest, List<CntDetalleComprobante>>
{
    private readonly CntContext context;

    public ListaDetalleComprobantesHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<List<CntDetalleComprobante>> Handle(ListaDetalleComprobantesRequest request, CancellationToken cancellationToken)
    {
        var detalleComprobantes = await context.cntDetalleComprobantes.ToListAsync();
        return detalleComprobantes;
    }
}