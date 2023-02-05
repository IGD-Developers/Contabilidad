namespace ContabilidadWebAPI.Aplicacion.Contabilidad.FormatoColumnas;

public class ListaCntFormatoColumnasRequest : IRequest<List<CntFormatoColumna>>
{ }

public class ListaCntFormatoColumnasHandler : IRequestHandler<ListaCntFormatoColumnasRequest, List<CntFormatoColumna>>
{

    private readonly CntContext context;

    public ListaCntFormatoColumnasHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<List<CntFormatoColumna>> Handle(ListaCntFormatoColumnasRequest request, CancellationToken cancellationToken)
    {
        var formatoColumnas = await context.cntFormatoColumnas.ToListAsync();
        return formatoColumnas;


    }
}