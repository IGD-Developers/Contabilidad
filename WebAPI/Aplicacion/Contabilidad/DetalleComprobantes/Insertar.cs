namespace ContabilidadWebAPI.Aplicacion.Contabilidad.DetalleComprobantes;

public class InsertarDetalleComprobanteRequest : IRequest
{

    public int IdComprobante { get; set; }
    public int IdCentrocosto { get; set; }
    public int IdPuc { get; set; }
    public int IdTercero { get; set; }
    public double DcoBase { get; set; }
    public double DcoTarifa { get; set; }
    public double DcoDebito { get; set; }
    public double DcoCredito { get; set; }
    public string DcoDetalle { get; set; }
}
public class InsertarDetalleComprobanteValidator : AbstractValidator<InsertarDetalleComprobanteRequest>
{
    public InsertarDetalleComprobanteValidator()
    {
        RuleFor(x => x.IdComprobante).NotEmpty();
        RuleFor(x => x.IdCentrocosto).NotEmpty();
        RuleFor(x => x.IdPuc).NotEmpty();
        RuleFor(x => x.IdTercero).NotEmpty();
        RuleFor(x => x.DcoTarifa).NotEmpty();
        RuleFor(x => x.DcoDebito).NotEmpty();
        RuleFor(x => x.DcoCredito).NotEmpty();
        RuleFor(x => x.DcoDetalle).NotEmpty();
    }
}
public class InsertarDetalleComprobanteHandler : IRequestHandler<InsertarDetalleComprobanteRequest>
{

    private readonly CntContext context;

    public InsertarDetalleComprobanteHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<Unit> Handle(InsertarDetalleComprobanteRequest request, CancellationToken cancellationToken)
    {

        var detalleComprobante = new CntDetalleComprobante
        {

            IdComprobante = request.IdComprobante,
            IdCentrocosto = request.IdCentrocosto,
            IdPuc = request.IdPuc,
            IdTercero = request.IdTercero,
            DcoBase = request.DcoBase,
            DcoTarifa = request.DcoTarifa,
            DcoDebito = request.DcoTarifa,
            DcoCredito = request.DcoCredito,
            DcoDetalle = request.DcoDetalle
        };

        context.cntDetalleComprobantes.Add(detalleComprobante);
        var respuesta = await context.SaveChangesAsync();
        if (respuesta > 0)
        {
            return Unit.Value;
        }
        throw new Exception("Error 112 al insertar Detalle");
    }
}