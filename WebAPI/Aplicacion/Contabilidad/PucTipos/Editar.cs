namespace ContabilidadWebAPI.Aplicacion.Contabilidad.PucTipos;

public class EditarPucTipoRequest : IRequest
{
    public int Id { get; set; }
    public string Codigo { get; set; }
    public string Nombre { get; set; }

}
public class EditarPucTipoValidator : AbstractValidator<EditarPucTipoRequest>
{
    public EditarPucTipoValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Codigo).NotEmpty();
        RuleFor(x => x.Nombre).NotEmpty();

    }
}


public class EditarPucTipoHandler : IRequestHandler<EditarPucTipoRequest>
{
    private readonly CntContext context;

    public EditarPucTipoHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<Unit> Handle(EditarPucTipoRequest request, CancellationToken cancellationToken)
    {

        var PucTipo = await context.cntPucTipos.FindAsync(request.Id);
        if (PucTipo == null)
        {
            throw new Exception("Registro no encontrado");
        };

        PucTipo.Codigo = request.Codigo;
        PucTipo.Nombre = request.Nombre;

        var resultado = await context.SaveChangesAsync();
        if (resultado > 0)
        {
            return Unit.Value;
        }

        throw new Exception("Error al modificar registro");

    }
}