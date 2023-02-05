namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Anos;

public class ConsultarAnoRequest : IdAnoModel, IRequest<CntAno>
{ }

public class ConsultarAnoHandler : IRequestHandler<ConsultarAnoRequest, CntAno>
{
    private readonly CntContext context;

    public ConsultarAnoHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<CntAno> Handle(ConsultarAnoRequest request, CancellationToken cancellationToken)
    {
        var ano = await context.cntAnos.FindAsync(request.Id);
        if (ano == null)
        {
            throw new Exception("Registro no encontrado");
        };
        return ano;

    }
}