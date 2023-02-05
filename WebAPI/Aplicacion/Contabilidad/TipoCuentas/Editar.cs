namespace ContabilidadWebAPI.Aplicacion.Contabilidad.TipoCuentas;

public class EditarTipoCuentaRequest : IRequest
{

    public int Id { get; set; }
    public string Codigo { get; set; }
    public string Nombre { get; set; }

}

public class EditarTipoCuentaValidator : AbstractValidator<EditarTipoCuentaRequest>
{
    public EditarTipoCuentaValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Codigo).NotEmpty();
        RuleFor(x => x.Nombre).NotEmpty();

    }
}

public class EditarTipoCuentaHandler : IRequestHandler<EditarTipoCuentaRequest>
{

    private readonly CntContext context;

    public EditarTipoCuentaHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<Unit> Handle(EditarTipoCuentaRequest request, CancellationToken cancellationToken)
    {
        var TipoCuenta = await context.cntTipoCuentas.FindAsync(request.Id);
        if (TipoCuenta == null)
        {
            throw new Exception("Registro no encontrado");
        };

        TipoCuenta.Codigo = request.Codigo;
        TipoCuenta.Nombre = request.Nombre;

        var resultado = await context.SaveChangesAsync();
        if (resultado > 0)
        {
            return Unit.Value;
        }
        throw new Exception("Error al modificar registro");



    }
}