using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;

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