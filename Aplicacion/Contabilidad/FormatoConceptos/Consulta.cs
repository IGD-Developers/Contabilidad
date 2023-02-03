using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dominio.Contabilidad;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Contabilidad.FormatoConceptos;

public class Consulta
{

    public class ListaCntFormatoConceptos : IRequest<List<CntFormatoConcepto>>
    {


    }


    public class Manejador : IRequestHandler<ListaCntFormatoConceptos, List<CntFormatoConcepto>>
    {

        private readonly CntContext context;

        public Manejador(CntContext context)
        {
            this.context = context;
        }

        public async Task<List<CntFormatoConcepto>> Handle(ListaCntFormatoConceptos request, CancellationToken cancellationToken)
        {

            var formatoConceptos = await context.cntFormatoConceptos.ToListAsync();
            return formatoConceptos;
        }
    }

}