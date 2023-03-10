namespace ContabilidadWebAPI.Aplicacion.Contabilidad.ConceptoCuentas;

public class EditarConceptoCuentaRequest : IRequest
{
    public int Id { get; set; }
    public int IdExogenaconcepto { get; set; }
    public int IdPuc { get; set; }
    public int IdFormatocolumna { get; set; }
    public int IdTipooperacion { get; set; }
    public string Estado { get; set; }
}

public class EditarConceptoCuentaValidator : AbstractValidator<EditarConceptoCuentaRequest>
{
    public EditarConceptoCuentaValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.IdExogenaconcepto).NotEmpty();
        RuleFor(x => x.IdPuc).NotEmpty();
        RuleFor(x => x.IdFormatocolumna).NotEmpty();
        RuleFor(x => x.IdTipooperacion).NotEmpty();
        RuleFor(x => x.Estado).NotEmpty();

    }
}

public class EditarConceptoCuentaHandler : IRequestHandler<EditarConceptoCuentaRequest>
{
    private readonly CntContext context;

    public EditarConceptoCuentaHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<Unit> Handle(EditarConceptoCuentaRequest request, CancellationToken cancellationToken)
    {
        var conceptoCuenta = await context.cntConceptoCuentas.FindAsync(request.Id);

        if (conceptoCuenta == null)
        {
            throw new Exception("Concepto no encontrado");
        };

        conceptoCuenta.IdExogenaconcepto = request.IdExogenaconcepto;
        conceptoCuenta.IdPuc = request.IdPuc;
        conceptoCuenta.IdFormatocolumna = request.IdFormatocolumna;
        conceptoCuenta.IdTipooperacion = request.IdTipooperacion;
        conceptoCuenta.Estado = request.Estado;

        var resultado = await context.SaveChangesAsync();
        if (resultado > 0)
        {
            return Unit.Value;
        }

        throw new Exception("Error al modificar registro");

    }


}