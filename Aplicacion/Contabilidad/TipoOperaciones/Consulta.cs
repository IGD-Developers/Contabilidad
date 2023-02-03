using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dominio.Contabilidad;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Contabilidad.TipoOperaciones;

public class Consulta
{

    public class ListaCntTipoOperaciones : IRequest<List<CntTipoOperacion>>
    {

    }

    public class Manejador : IRequestHandler<ListaCntTipoOperaciones, List<CntTipoOperacion>>
    {
        private readonly CntContext context;

        public Manejador(CntContext context)
        {
            this.context = context;
        }

        public async Task<List<CntTipoOperacion>> Handle(ListaCntTipoOperaciones request, CancellationToken cancellationToken)
        {
            var tipoOperaciones = await context.cntTipoOperaciones.ToListAsync();
            return tipoOperaciones;
        }
    }

}