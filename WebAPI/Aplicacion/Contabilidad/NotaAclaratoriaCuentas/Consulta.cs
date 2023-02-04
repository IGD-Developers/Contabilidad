using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.NotaAclaratoriaCuentas;

public class Consulta
{
    public class ListaCntNotaAclaratoriaCuentas : IRequest<List<CntNotaAclaratoriaCuenta>>
    {


    }


    public class Manejador : IRequestHandler<ListaCntNotaAclaratoriaCuentas, List<CntNotaAclaratoriaCuenta>>
    {

        private readonly CntContext context;

        public Manejador(CntContext context)
        {
            this.context = context;
        }

        public async Task<List<CntNotaAclaratoriaCuenta>> Handle(ListaCntNotaAclaratoriaCuentas request, CancellationToken cancellationToken)
        {

            var notasAclaratoriasCuentas = await context.cntNotaAclaratoriaCuentas.ToListAsync();
            return notasAclaratoriasCuentas;

        }
    }



}