using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.DetalleComprobantes;

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