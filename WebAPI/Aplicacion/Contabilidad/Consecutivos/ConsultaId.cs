using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using ContabilidadWebAPI.Persistencia;
using ContabilidadWebAPI.Dominio.Contabilidad;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Consecutivos;

public class ConsultarConsecutivoRequest : IRequest<CntConsecutivo>
{
    public int Id { get; set; }
}
public class ConsultarConsecutivoHandler : IRequestHandler<ConsultarConsecutivoRequest, CntConsecutivo>
{
    private readonly CntContext context;

    public ConsultarConsecutivoHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<CntConsecutivo> Handle(ConsultarConsecutivoRequest request, CancellationToken cancellationToken)
    {
        var consecutivo = await context.cntConsecutivos.FindAsync(request.Id);
        if (consecutivo == null)
        {
            throw new Exception("Registro no encontrado");
        };
        return consecutivo;
    }
}