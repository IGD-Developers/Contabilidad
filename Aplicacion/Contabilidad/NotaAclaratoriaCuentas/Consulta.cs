using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dominio.Contabilidad;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Contabilidad.NotaAclaratoriaCuentas
{
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
}