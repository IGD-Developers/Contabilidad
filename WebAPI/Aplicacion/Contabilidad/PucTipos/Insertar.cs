namespace ContabilidadWebAPI.Aplicacion.Contabilidad.PucTipos;

public class InsertarPucTipoRequest : IRequest
{
    public string Codigo { get; set; }
    public string Nombre { get; set; }

}

public class InsertarPucTipoValidator : AbstractValidator<InsertarPucTipoRequest>
{
    public InsertarPucTipoValidator()
    {
        RuleFor(x => x.Codigo).NotEmpty();
        RuleFor(x => x.Nombre).NotEmpty();

    }
}

public class InsertarPucTipoHandler : IRequestHandler<InsertarPucTipoRequest>
{
    private readonly CntContext context;

    public InsertarPucTipoHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<Unit> Handle(InsertarPucTipoRequest request, CancellationToken cancellationToken)
    {
        var PucTipo = new CntPucTipo
        {
            Codigo = request.Codigo,
            Nombre = request.Nombre
        };
        context.cntPucTipos.Add(PucTipo);
        var respuesta = await context.SaveChangesAsync();
        if (respuesta > 0)
        {
            return Unit.Value;
        }

        throw new Exception("Error 107 al insertar en PucTipo");
    }
}