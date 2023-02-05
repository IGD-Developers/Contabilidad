using MediatR;
using System.Threading.Tasks;
using System.Threading;
using ContabilidadWebAPI.Persistencia;
using ContabilidadWebAPI.Dominio.Contabilidad;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.NotaAclaratoriaCuentas;

public class ConsultarNotaAclaratoriaCuentaRequest : IRequest<CntNotaAclaratoriaCuenta>
{

    public int Id { get; set; }
}

public class ConsultarNotaAclaratoriaCuentaHandler : IRequestHandler<ConsultarNotaAclaratoriaCuentaRequest, CntNotaAclaratoriaCuenta>
{
    private readonly CntContext context;

    public ConsultarNotaAclaratoriaCuentaHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<CntNotaAclaratoriaCuenta> Handle(ConsultarNotaAclaratoriaCuentaRequest request, CancellationToken cancellationToken)
    {
        var notaAclaratoriaCuenta = await context.cntNotaAclaratoriaCuentas.FindAsync(request.Id);
        return notaAclaratoriaCuenta;
    }
}