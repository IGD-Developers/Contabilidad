namespace ContabilidadWebAPI.Aplicacion.Contabilidad.ConceptoCuentas;

public class ConsultarConceptoCuentaRequest : IRequest<CntConceptoCuenta>
{
    public int Id { get; set; }

}

public class ConsultarConceptoCuentaHandler : IRequestHandler<ConsultarConceptoCuentaRequest, CntConceptoCuenta>
{
    private readonly CntContext context;

    public ConsultarConceptoCuentaHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<CntConceptoCuenta> Handle(ConsultarConceptoCuentaRequest request, CancellationToken cancellationToken)
    {
        var conceptoCuenta = await context.cntConceptoCuentas.FindAsync(request.Id);
        if (conceptoCuenta == null)
        {
            throw new Exception("Registro no encontrado");
        };
        return conceptoCuenta;

    }
}