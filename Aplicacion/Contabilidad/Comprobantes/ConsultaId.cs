using MediatR;
using Persistencia;
using System.Threading.Tasks;
using System.Threading;
using Dominio.Contabilidad;
using System;
using Aplicacion.Models.Contabilidad.Comprobantes;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Aplicacion.Contabilidad.Comprobantes


{

    public class ConsultaId {

    public class ConsultarId: IdComprobanteModel,IRequest<ListarComprobantesModel> 
    {  }

    public class Manejador :IRequestHandler<ConsultarId,ListarComprobantesModel>{

        private readonly CntContext context;
        private readonly IMapper _mapper;


            public Manejador(CntContext context, IMapper mapper)
            {
                this.context = context;
                _mapper = mapper;
            }

            public async Task<ListarComprobantesModel> Handle(ConsultarId request, CancellationToken cancellationToken)
            {
                // var comprobante = await context.cntComprobantes.FindAsync(request.Id);
                // if (comprobante == null) {
                //     throw new Exception("Registro no encontrado");
                // };              
                // return comprobante;

                var comprobante = await context.cntComprobantes
                .Include(t => t.tipoComprobante)
                .ThenInclude(ctg => ctg.categoria)
                .Include(s => s.sucursal)
                .Include(u => u.usuario)
                .Include(d => d.comprobanteDetalleComprobantes)
                .FirstOrDefaultAsync(cmp => cmp.id == request.Id);
                // Nota:la condicion del FirstOrDefaultAsync puede ir en un Where(cmp => cmp.id == request.Id) 

                if (comprobante == null) {
                    throw new Exception("Registro no encontrado");
                };     
                var comprobanteDto = _mapper.Map<CntComprobante,ListarComprobantesModel>(comprobante);         
                return comprobanteDto;

            }
        }


}
}