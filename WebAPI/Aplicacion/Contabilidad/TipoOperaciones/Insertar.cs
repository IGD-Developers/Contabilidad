namespace ContabilidadWebAPI.Aplicacion.Contabilidad.TipoOperaciones;

public class InsertarTipoOperacionRequest : IRequest
{

    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public string formula { get; set; }

}

public class InsertarTipoOperacionValidator : AbstractValidator<InsertarTipoOperacionRequest>
{
    public InsertarTipoOperacionValidator()
    {
        RuleFor(x => x.Codigo).NotEmpty();
        RuleFor(x => x.Nombre).NotEmpty();

    }
}


public class InsertarTipoOperacionHandler : IRequestHandler<InsertarTipoOperacionRequest>
{

    private readonly CntContext context;

    public InsertarTipoOperacionHandler(CntContext context)
    {
        this.context = context;
    }

    public class InsertarTipoOperacionValidator : AbstractValidator<InsertarTipoOperacionRequest>
    {
        public InsertarTipoOperacionValidator()
        {
            RuleFor(x => x.Codigo).NotEmpty();
            RuleFor(x => x.Nombre).NotEmpty();

        }
    }


    public async Task<Unit> Handle(InsertarTipoOperacionRequest request, CancellationToken cancellationToken)
    {

        var tipoOperacion = new CntTipoOperacion
        {
            Codigo = request.Codigo,
            Nombre = request.Nombre,
            Formula = request.formula ?? ""

        };


        context.cntTipoOperaciones.Add(tipoOperacion);
        var respuesta = await context.SaveChangesAsync();
        if (respuesta > 0)
        {
            return Unit.Value;
        }

        throw new Exception("Error al insertar TipoOperacion");
    }
}