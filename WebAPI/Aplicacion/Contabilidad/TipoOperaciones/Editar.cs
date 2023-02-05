namespace ContabilidadWebAPI.Aplicacion.Contabilidad.TipoOperaciones;

public class EditarTipoOperacionRequest : IRequest
{
    public int Id { get; set; }
    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public string formula { get; set; }

}

public class EditarTipoOperacionValidator : AbstractValidator<EditarTipoOperacionRequest>
{
    public EditarTipoOperacionValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Codigo).NotEmpty();
        RuleFor(x => x.Nombre).NotEmpty();

    }
}


public class EditarTipoOperacionHandler : IRequestHandler<EditarTipoOperacionRequest>
{

    private readonly CntContext context;

    public EditarTipoOperacionHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<Unit> Handle(EditarTipoOperacionRequest request, CancellationToken cancellationToken)
    {
        var tipoOperacion = await context.cntTipoOperaciones.FindAsync(request.Id);
        if (tipoOperacion == null)
        {
            throw new Exception("Registro no encontrado");
        };

        tipoOperacion.Codigo = request.Codigo;
        tipoOperacion.Nombre = request.Nombre;
        tipoOperacion.Formula = request.formula ?? tipoOperacion.Formula;
        var resultado = await context.SaveChangesAsync();
        if (resultado > 0)
        {
            return Unit.Value;
        }
        throw new Exception("Error al modificar registro");



    }
}