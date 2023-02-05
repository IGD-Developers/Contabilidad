using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.PucTipos;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.PucTipos;

public class ConsultarPucTipoRequest : IdPucTipoModel, IRequest<CntPucTipo>
{ }


public class ConsultarPucTipoHandler : IRequestHandler<ConsultarPucTipoRequest, CntPucTipo>
{

    private readonly CntContext context;

    public ConsultarPucTipoHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<CntPucTipo> Handle(ConsultarPucTipoRequest request, CancellationToken cancellationToken)
    {

        var PucTipo = await context.cntPucTipos.FindAsync(request.Id);
        if (PucTipo == null)
        {
            throw new Exception("Registro no encontrado");
        };
        return PucTipo;

    }


}
