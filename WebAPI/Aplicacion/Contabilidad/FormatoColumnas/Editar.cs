namespace ContabilidadWebAPI.Aplicacion.Contabilidad.FormatoColumnas;

public class EditarFormatoColumnaRequest : IRequest
{

    public int Id { get; set; }
    public int IdExogenaformato { get; set; }
    public string FcoColumna { get; set; }
    public string FcoCampo { get; set; }
    public string FcoTipo { get; set; }
}

public class EditarFormatoColumnaValidator : AbstractValidator<EditarFormatoColumnaRequest>
{
    public EditarFormatoColumnaValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.IdExogenaformato).NotEmpty();
        RuleFor(x => x.FcoColumna).NotEmpty();
        RuleFor(x => x.FcoCampo).NotEmpty();
        RuleFor(x => x.FcoTipo).NotEmpty();

    }
}

public class EditarFormatoColumnaHandler : IRequestHandler<EditarFormatoColumnaRequest>
{
    private readonly CntContext context;

    public EditarFormatoColumnaHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<Unit> Handle(EditarFormatoColumnaRequest request, CancellationToken cancellationToken)
    {

        var formatoColumna = await context.cntFormatoColumnas.FindAsync(request.Id);
        if (formatoColumna == null)
        {
            throw new Exception("Registro no encontrado");
        };
        formatoColumna.IdExogenaformato = request.IdExogenaformato;
        formatoColumna.FcoColumna = request.FcoColumna; ;
        formatoColumna.FcoCampo = request.FcoCampo; ;
        formatoColumna.FcoTipo = request.FcoTipo;

        var resultado = await context.SaveChangesAsync();
        if (resultado > 0)
        {
            return Unit.Value;
        }

        throw new Exception("Error al modificar registro");




    }
}


