using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Persistencia;
using Dominio.Contabilidad;
using System;
using Aplicacion.Models.Contabilidad.LiquidaImpuestos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Aplicacion.Contabilidad.LiquidaImpuestos
{
    public class ConsultaId
    {
        public class ConsultarId : IdLiquidaImpuestoModel, IRequest<ListarLiquidaImpuestosModel>
        { }



        public class Manejador : IRequestHandler<ConsultarId, ListarLiquidaImpuestosModel>
        {
            private CntContext _context;

            private readonly IMapper _mapper;



            public Manejador(CntContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ListarLiquidaImpuestosModel> Handle(ConsultarId request, CancellationToken cancellationToken)
            {

                var entidad = await _context.cntLiquidaImpuestos
                .Include(t => t.Tercero)
               .Include(ti => ti.TipoImpuesto)
               .Include(co => co.Comprobante)
               .ThenInclude(tipoc => tipoc.TipoComprobante)
               .Include(co => co.Comprobante)
               .ThenInclude(dt => dt.ComprobanteDetalleComprobantes)
               .Where(i => i.Id == request.Id)
                .Select(p => _mapper.Map<CntLiquidaImpuesto, ListarLiquidaImpuestosModel>(p))
               .FirstOrDefaultAsync();

                if (entidad == null)
                {
                    throw new Exception("Registro no encontrado");
                };

                return entidad;
            }
        }

    }
}