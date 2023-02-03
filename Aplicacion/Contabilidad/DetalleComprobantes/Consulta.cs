using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dominio.Contabilidad;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Contabilidad.DetalleComprobantes;

public class Consulta
{

    public class ListaDetalleComprobantes : IRequest<List<CntDetalleComprobante>>
    {


    }

    public class Manejador : IRequestHandler<ListaDetalleComprobantes, List<CntDetalleComprobante>>
    {
        private readonly CntContext context;

        public Manejador(CntContext context)
        {
            this.context = context;
        }

        public async Task<List<CntDetalleComprobante>> Handle(ListaDetalleComprobantes request, CancellationToken cancellationToken)
        {
            var detalleComprobantes = await context.cntDetalleComprobantes.ToListAsync();
            return detalleComprobantes;
        }
    }


}