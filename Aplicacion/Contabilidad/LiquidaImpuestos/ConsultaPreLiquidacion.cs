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
            /// Recibe un json FiltroGeneraImpuestosModel con:  IdTipoimpuesto,IdSucursal, IdEntidad, FechaInicial,FechaFinal             /// </summary>
            /// <returns> Un objeto ListarDetallesPreLiquidacionImpuestoModel con los registros de detalleComprobante que se cerrarán
            ///</returns>
            public async Task<List<ListarDetallesPreLiquidacionImpuestoModel>> Handle(ConsultarPreLiquidacion request, CancellationToken cancellationToken)
            {

                var entidad =  await _context.cntEntidades
                    .Where(e => e.Id ==request.IdEntidad && e.IdTipoimpuesto == request.IdTipoimpuesto)
                    .Select(e=> new IdLiquidaImpuestoModel(){Id = e.Id})
                    .FirstOrDefaultAsync();

                if (entidad ==null)
                    { throw new Exception("No se ha configurado correctamente la Entidad con su tipo de impuesto");}

                var cuentaCierre =  await _context.cntCuentaImpuestos
                    .Where(ci => ci.IdTipoimpuesto == request.IdTipoimpuesto)
                    .Select(ci=> new IdLiquidaImpuestoModel(){Id = ci.IdPuc})
                    .FirstOrDefaultAsync();

                if (cuentaCierre ==null)
                { throw new Exception("No se ha configurado la contrapartida para el tipo de Impuesto");}

                // request.FechaInicial = (request.FechaInicial == null) ? DateTime.Now : request.FechaInicial;
                // request.FechaFinal = (request.FechaFinal == null) ? DateTime.Now : request.FechaFinal;

                //===============================================
                //Revisar en el rango de fechas los comprobantes que no sean tipo LIM en Comprobante  
                //y con la relación de detalle extraer los registros marcados como "A"ctivos
                //de aquellos comprobantes que tienen cuentas con este tipo de impuesto. 
                //Revisar en cntPuc las cuentas que tienen el tipo de impuesto request.IdTipoimpuesto
                //Revisar los movimientos en detallecomprobante y extraer los movimientos que tienen incluidas esas cuentas
                //===============================================

                var entidadesDto = await _context.cntDetalleComprobantes
                .Include(d => d.Tercero)
                .Include(d => d.Puc)
                .Where(p=>p.Puc.IdTipoimpuesto==request.IdTipoimpuesto)
                .Include(c=>c.Comprobante)
                .Where(co=>co.Comprobante.CcoFecha>= request.FechaInicial
                            && co.Comprobante.CcoFecha<= request.FechaFinal
                            && co.Comprobante.IdSucursal == request.IdSucursal
                            && co.Comprobante.Estado == "A")
                .Include(co=>co.Comprobante)
                .ThenInclude(t=>t.Usuario)
                .ThenInclude(tu=>tu.Tercero)
                .Select(p => _mapper.Map<CntDetalleComprobante, ListarDetallesPreLiquidacionImpuestoModel>(p))
                .ToListAsync();
              
                return entidadesDto;

              
            }
        }

    }
}