using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using ContabilidadWebAPI.Persistencia;
using ContabilidadWebAPI.Dominio.Contabilidad;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.ConceptoCuentas;

public class Consulta
{

    public class ListaCntConceptoCuentas : IRequest<List<CntConceptoCuenta>>
    {

    }


    public class Manejador : IRequestHandler<ListaCntConceptoCuentas, List<CntConceptoCuenta>>
    {
        private readonly CntContext context;

        public Manejador(CntContext context)
        {
            this.context = context;
        }

        public async Task<List<CntConceptoCuenta>> Handle(ListaCntConceptoCuentas request, CancellationToken cancellationToken)
        {
            var conceptoCuentas = await context.cntConceptoCuentas.ToListAsync();
            return conceptoCuentas;
        }
    }

}