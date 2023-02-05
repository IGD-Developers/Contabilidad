using MediatR;
using System.Threading.Tasks;
using System.Threading;
using ContabilidadWebAPI.Persistencia;
using ContabilidadWebAPI.Dominio.Contabilidad;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.NotaAclaratoriaTipos;

public class ConsultarNotaAclaratoriaTipoRequest : IRequest<CntNotaAclaratoriaTipo>
{

    public int Id { get; set; }
}

public class ConsultarNotaAclaratoriaTipoHandler : IRequestHandler<ConsultarNotaAclaratoriaTipoRequest, CntNotaAclaratoriaTipo>
{

    private readonly CntContext context;

    public ConsultarNotaAclaratoriaTipoHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<CntNotaAclaratoriaTipo> Handle(ConsultarNotaAclaratoriaTipoRequest request, CancellationToken cancellationToken)
    {
        var notaAclaratoriaTipo = await context.cntNotaAclaratoriaTipos.FindAsync(request.Id);
        return notaAclaratoriaTipo;

    }
}