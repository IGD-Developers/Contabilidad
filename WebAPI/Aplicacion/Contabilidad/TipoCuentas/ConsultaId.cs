namespace ContabilidadWebAPI.Aplicacion.Contabilidad.TipoCuentas;

public class ConsultarTipoCuentaRequest : IRequest<CntTipoCuenta>
{
    public int Id { get; set; }
}

public class ConsultarTipoCuentaHandler : IRequestHandler<ConsultarTipoCuentaRequest, CntTipoCuenta>
{

    private readonly CntContext context;

    public ConsultarTipoCuentaHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<CntTipoCuenta> Handle(ConsultarTipoCuentaRequest request, CancellationToken cancellationToken)
    {

        var TipoCuenta = await context.cntTipoCuentas.FindAsync(request.Id);
        if (TipoCuenta == null)
        {
            throw new Exception("Registro no encontrado");
        };

        return TipoCuenta;
    }
}