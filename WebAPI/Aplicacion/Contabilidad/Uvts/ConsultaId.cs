namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Uvts;

public class ConsultarUvtRequest : IRequest<CntUvt>
{

    public int Id { get; set; }
}

public class ConsultarUvtHandler : IRequestHandler<ConsultarUvtRequest, CntUvt>
{
    private readonly CntContext context;

    public ConsultarUvtHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<CntUvt> Handle(ConsultarUvtRequest request, CancellationToken cancellationToken)
    {
        var uvt = await context.cntUvts.FindAsync(request.Id);
        if (uvt == null)
        {
            throw new Exception("Registro no encontrado");
        };

        return uvt;
    }
}