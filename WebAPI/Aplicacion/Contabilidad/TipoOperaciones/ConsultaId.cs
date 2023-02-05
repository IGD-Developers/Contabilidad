namespace ContabilidadWebAPI.Aplicacion.Contabilidad.TipoOperaciones;

public class ConsultarTipoOperacionRequest : IRequest<CntTipoOperacion>
{

    public int Id { get; set; }
}

public class ConsultarTipoOperacionHandler : IRequestHandler<ConsultarTipoOperacionRequest, CntTipoOperacion>
{

    private readonly CntContext context;

    public ConsultarTipoOperacionHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<CntTipoOperacion> Handle(ConsultarTipoOperacionRequest request, CancellationToken cancellationToken)
    {
        var tipoOperacion = await context.cntTipoOperaciones.FindAsync(request.Id);
        if (tipoOperacion == null)
        {
            throw new Exception("Registro no encontrado");
        };
        return tipoOperacion;

    }
}