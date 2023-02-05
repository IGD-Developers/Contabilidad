namespace ContabilidadWebAPI.Aplicacion.Contabilidad.LiquidaImpuestos;

public class EditarLiquidaImpuestoRequest : IRequest
{
    public int Id { get; set; }
    public int IdTipoimpuesto { get; set; }
    public int IdComprobante { get; set; }
    public int IdPuc { get; set; }
    public int IdTercero { get; set; }
    public DateTime LimFecha { get; set; }
    public DateTime LimFechainicial { get; set; }
    public DateTime LimFechafinal { get; set; }
    public string IdUsuario { get; set; }
}

public class EditarLiquidaImpuestoValidator : AbstractValidator<EditarLiquidaImpuestoRequest>
{
    public EditarLiquidaImpuestoValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.IdTipoimpuesto).NotEmpty();
        RuleFor(x => x.IdComprobante).NotEmpty();
        RuleFor(x => x.IdPuc).NotEmpty();
        RuleFor(x => x.IdTercero).NotEmpty();
        RuleFor(x => x.LimFechainicial).NotEmpty();
        RuleFor(x => x.LimFechafinal).NotEmpty();
        RuleFor(x => x.IdUsuario).NotEmpty();
    }
}

public class EditarLiquidaImpuestoHandler : IRequestHandler<EditarLiquidaImpuestoRequest>
{
    private readonly CntContext context;

    public EditarLiquidaImpuestoHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<Unit> Handle(EditarLiquidaImpuestoRequest request, CancellationToken cancellationToken)
    {


        var liquidaImpuesto = await context.cntLiquidaImpuestos.FindAsync(request.Id);
        if (liquidaImpuesto == null)
        {
            throw new Exception("Registro no encontrado");
        };
        liquidaImpuesto.IdTipoimpuesto = request.IdTipoimpuesto;
        liquidaImpuesto.IdComprobante = request.IdComprobante;
        liquidaImpuesto.IdPuc = request.IdPuc;
        liquidaImpuesto.IdTercero = request.IdTercero;
        //liquidaImpuesto.LimFecha = request.LimFecha;
        liquidaImpuesto.LimFechainicial = request.LimFechainicial;
        liquidaImpuesto.LimFechafinal = request.LimFechafinal;
        // liquidaImpuesto.IdUsuario = request.IdUsuario;

        var resultado = await context.SaveChangesAsync();
        if (resultado > 0)
        {
            return Unit.Value;
        }

        throw new Exception("Error al modificar registro");



    }
}