namespace ContabilidadWebAPI.Aplicacion.Contabilidad.ExogenaFormatos;

public class ConsultarExogenaFormatoRequest : IRequest<CntExogenaFormato>
{

    public int Id { get; set; }
}

public class ConsultarExogenaFormatoHandler : IRequestHandler<ConsultarExogenaFormatoRequest, CntExogenaFormato>
{
    private readonly CntContext context;

    public ConsultarExogenaFormatoHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<CntExogenaFormato> Handle(ConsultarExogenaFormatoRequest request, CancellationToken cancellationToken)
    {
        var exogenaFormato = await context.cntExogenaFormatos.FindAsync(request.Id);
        if (exogenaFormato == null)
        {
            throw new Exception("Registro no encontrado");
        };

        return exogenaFormato;
    }
}