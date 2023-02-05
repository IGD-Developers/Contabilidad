using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Meses;

public class ConsultarMesRequest : IRequest<CntMes>
{
    public int Id { get; set; }
}

public class ConsultarMesHandler : IRequestHandler<ConsultarMesRequest, CntMes>
{
    private readonly CntContext context;

    public ConsultarMesHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<CntMes> Handle(ConsultarMesRequest request, CancellationToken cancellationToken)
    {
        var mes = await context.cntMeses.FindAsync(request.Id);
        if (mes == null)
        {
            throw new Exception("Registro no encontrado");
        };

        return mes;
    }
}