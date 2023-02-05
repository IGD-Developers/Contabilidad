namespace ContabilidadWebAPI.Aplicacion.Contabilidad.DetalleComprobantes;

public class ConsultarDetalleComprobanteRequest : IRequest<CntDetalleComprobante>
{

    public int Id { get; set; }
}

public class ConsultarDetalleComprobanteHandler : IRequestHandler<ConsultarDetalleComprobanteRequest, CntDetalleComprobante>
{
    private readonly CntContext context;

    public ConsultarDetalleComprobanteHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<CntDetalleComprobante> Handle(ConsultarDetalleComprobanteRequest request, CancellationToken cancellationToken)
    {
        var detalleComprobante = await context.cntDetalleComprobantes.FindAsync(request.Id);
        if (detalleComprobante == null)
        {
            throw new Exception("Registro no encontrado");
        };
        return detalleComprobante;
    }
}