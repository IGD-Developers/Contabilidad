namespace ContabilidadWebAPI.Aplicacion.Contabilidad.TipoCuentas;

public class ListaCntTipoCuentasRequest : IRequest<List<CntTipoCuenta>>
{

}

public class ListaCntTipoCuentasHandler : IRequestHandler<ListaCntTipoCuentasRequest, List<CntTipoCuenta>>
{
    private readonly CntContext context;

    public ListaCntTipoCuentasHandler(CntContext _context)
    {
        context = _context;
    }

    public async Task<List<CntTipoCuenta>> Handle(ListaCntTipoCuentasRequest request, CancellationToken cancellationToken)
    {
        var tipoCuentas = await context.cntTipoCuentas.ToListAsync();
        return tipoCuentas;

    }
}