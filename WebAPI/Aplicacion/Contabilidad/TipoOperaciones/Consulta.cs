namespace ContabilidadWebAPI.Aplicacion.Contabilidad.TipoOperaciones;

public class ListaCntTipoOperacionesRequest : IRequest<List<CntTipoOperacion>>
{

}

public class ListaCntTipoOperacionesHandler : IRequestHandler<ListaCntTipoOperacionesRequest, List<CntTipoOperacion>>
{
    private readonly CntContext context;

    public ListaCntTipoOperacionesHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<List<CntTipoOperacion>> Handle(ListaCntTipoOperacionesRequest request, CancellationToken cancellationToken)
    {
        var tipoOperaciones = await context.cntTipoOperaciones.ToListAsync();
        return tipoOperaciones;
    }
}