using MediatR;
using Persistencia;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
//using Dominio.Contabilidad;
using Aplicacion.Models.Contabilidad.LiquidaImpuestos;
using AutoMapper;
using System.Linq;
using System;
using Dominio.Contabilidad;

namespace Aplicacion.Contabilidad.LiquidaImpuestos
{
    public class ConsultaPreLiquidacion
    {
        public class ConsultarPreLiquidacion : FiltroGeneraImpuestosModel, IRequest<List<ListarDetallesPreLiquidacionImpuestoModel>>
        { }

        public class Manejador : IRequestHandler<ConsultarPreLiquidacion, List<ListarDetallesPreLiquidacionImpuestoModel>>
        {
            private CntContext _context;
            private readonly IMapper _mapper;

            public Manejador(CntContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            /// <summary>
            /// Task Handle: Implementacion de ConsultarPreLiquidacion.Manejador -IRequestHandler<para></para>
            /// Recibe un json FiltroGeneraImpuestosModel con:  id_tipoimpuesto,id_sucursal, id_entidad, fechainicial,fechafinal             /// </summary>
            /// <returns> Un objeto ListarDetallesPreLiquidacionImpuestoModel con los registros de detalleComprobante que se cerrarán
            ///</returns>
            public async Task<List<ListarDetallesPreLiquidacionImpuestoModel>> Handle(ConsultarPreLiquidacion request, CancellationToken cancellationToken)
            {

                var entidad =  await _context.cntEntidades
                    .Where(e => e.id ==request.id_entidad && e.id_tipoimpuesto == request.id_tipoimpuesto)
                    .Select(e=> new IdLiquidaImpuestoModel(){Id = e.id})
                    .FirstOrDefaultAsync();

                if (entidad ==null)
                    { throw new Exception("No se ha configurado correctamente la Entidad con su tipo de impuesto");}

                var cuentaCierre =  await _context.cntCuentaImpuestos
                    .Where(ci => ci.id_tipoimpuesto == request.id_tipoimpuesto)
                    .Select(ci=> new IdLiquidaImpuestoModel(){Id = ci.id_puc})
                    .FirstOrDefaultAsync();

                if (cuentaCierre ==null)
                { throw new Exception("No se ha configurado la contrapartida para el tipo de Impuesto");}

                // request.fechainicial = (request.fechainicial == null) ? DateTime.Now : request.fechainicial;
                // request.fechafinal = (request.fechafinal == null) ? DateTime.Now : request.fechafinal;

                //===============================================
                //Revisar en el rango de fechas los comprobantes que no sean tipo LIM en Comprobante  
                //y con la relación de detalle extraer los registros marcados como "A"ctivos
                //de aquellos comprobantes que tienen cuentas con este tipo de impuesto. 
                //Revisar en cntPuc las cuentas que tienen el tipo de impuesto request.id_tipoimpuesto
                //Revisar los movimientos en detallecomprobante y extraer los movimientos que tienen incluidas esas cuentas
                //===============================================

                var entidadesDto = await _context.cntDetalleComprobantes
                .Include(d => d.tercero)
                .Include(d => d.puc)
                .Where(p=>p.puc.id_tipoimpuesto==request.id_tipoimpuesto)
                .Include(c=>c.comprobante)
                .Where(co=>co.comprobante.cco_fecha>= request.fechainicial
                            && co.comprobante.cco_fecha<= request.fechafinal
                            && co.comprobante.id_sucursal == request.id_sucursal
                            && co.comprobante.estado == "A")
                .Include(co=>co.comprobante)
                .ThenInclude(t=>t.usuario)
                .ThenInclude(tu=>tu.tercero)
                .Select(p => _mapper.Map<CntDetalleComprobante, ListarDetallesPreLiquidacionImpuestoModel>(p))
                .ToListAsync();
              
                return entidadesDto;

              
            }
        }

    }
}