namespace ContabilidadWebAPI.Aplicacion.Contabilidad.TipoCuentas;

public class InsertarTipoCuentaRequest : IRequest
{

    public string Codigo { get; set; }
    public string Nombre { get; set; }

}

public class InsertarTipoCuentaValidator : AbstractValidator<InsertarTipoCuentaRequest>
{
    public InsertarTipoCuentaValidator()
    {
        RuleFor(x => x.Codigo).NotEmpty();
        RuleFor(x => x.Nombre).NotEmpty();

    }
}


public class InsertarTipoCuentaHandler : IRequestHandler<InsertarTipoCuentaRequest>
{

    private readonly CntContext context;

    public InsertarTipoCuentaHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<Unit> Handle(InsertarTipoCuentaRequest request, CancellationToken cancellationToken)
    {
        var TipoCuenta = new CntTipoCuenta
        {
            Codigo = request.Codigo,
            Nombre = request.Nombre
        };

        context.cntTipoCuentas.Add(TipoCuenta);
        var respuesta = await context.SaveChangesAsync();
        if (respuesta > 0)
        {
            return Unit.Value;
        }
        throw new Exception("Error 108 al insertar tipocuenta");
    }
}