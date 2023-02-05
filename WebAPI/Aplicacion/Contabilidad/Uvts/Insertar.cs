namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Uvts;

public class InsertarUvtRequest : IRequest
{

    public int uvt_ano { get; set; }
    public double uvt_valor { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

}

public class InsertarUvtValidator : AbstractValidator<InsertarUvtRequest>
{
    public InsertarUvtValidator()
    {
        RuleFor(x => x.uvt_ano).NotEmpty();
        RuleFor(x => x.uvt_valor).NotEmpty();

    }
}


public class InsertarUvtHandler : IRequestHandler<InsertarUvtRequest>
{

    private readonly CntContext context;

    public InsertarUvtHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<Unit> Handle(InsertarUvtRequest request, CancellationToken cancellationToken)
    {
        var uvt = new CntUvt
        {
            UvtAno = request.uvt_ano,
            UvtValor = request.uvt_valor
        };

        context.cntUvts.Add(uvt);
        var respuesta = await context.SaveChangesAsync();
        if (respuesta > 0)
        {
            return Unit.Value;
        }

        throw new Exception("Error al insertar TipoOperacion");
    }
}
