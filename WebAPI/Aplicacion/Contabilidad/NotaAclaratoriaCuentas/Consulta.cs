namespace ContabilidadWebAPI.Aplicacion.Contabilidad.NotaAclaratoriaCuentas;

public class ListaCntNotaAclaratoriaCuentasRequest : IRequest<List<CntNotaAclaratoriaCuenta>>
{


}


public class ListaCntNotaAclaratoriaCuentasHandler : IRequestHandler<ListaCntNotaAclaratoriaCuentasRequest, List<CntNotaAclaratoriaCuenta>>
{

    private readonly CntContext context;

    public ListaCntNotaAclaratoriaCuentasHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<List<CntNotaAclaratoriaCuenta>> Handle(ListaCntNotaAclaratoriaCuentasRequest request, CancellationToken cancellationToken)
    {

        var notasAclaratoriasCuentas = await context.cntNotaAclaratoriaCuentas.ToListAsync();
        return notasAclaratoriasCuentas;

    }
}