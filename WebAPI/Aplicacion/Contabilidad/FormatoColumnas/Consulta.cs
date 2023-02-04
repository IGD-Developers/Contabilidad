using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.FormatoColumnas;

public class Consulta
{

    public class ListaCntFormatoColumnas : IRequest<List<CntFormatoColumna>>
    {



    }

    public class Manejador : IRequestHandler<ListaCntFormatoColumnas, List<CntFormatoColumna>>
    {

        private readonly CntContext context;

        public Manejador(CntContext context)
        {
            this.context = context;
        }

        public async Task<List<CntFormatoColumna>> Handle(ListaCntFormatoColumnas request, CancellationToken cancellationToken)
        {
            var formatoColumnas = await context.cntFormatoColumnas.ToListAsync();
            return formatoColumnas;


        }
    }

}