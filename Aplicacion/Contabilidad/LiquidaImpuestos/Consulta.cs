using MediatR;
using Persistencia;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Dominio.Contabilidad;
using Aplicacion.Models.Contabilidad.LiquidaImpuestos;
using AutoMapper;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacion.Contabilidad.LiquidaImpuestos
{
    public class Consulta
    {
        public class ListaCntLiquidaImpuestos : FiltroLiquidaImpuestosModel, IRequest<List<ListarLiquidaImpuestosModel>>
        { }


        public class Manejador : IRequestHandler<ListaCntLiquidaImpuestos, List<ListarLiquidaImpuestosModel>>
        {
            private CntContext _context;
            private readonly IMapper _mapper;

            public Manejador(CntContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }


            /// <summary>
            /// Task Handle: Implementacion de Consulta.Manejador -IRequestHandler
            /// </summary>
            /// <returns> Un objeto ListarLiquidaImpuestosModel con las liquidaciones de impuestos entre dos fechas
            ///</returns>
            public async Task<List<ListarLiquidaImpuestosModel>> Handle(ListaCntLiquidaImpuestos request, CancellationToken cancellationToken)
            {

                // var idTipoComprobante = await _context.cntTipoComprobantes
                //                     .Where(t => t.codigo == "LIM")
                //                     .Select(t => new IdLiquidaImpuestoModel()
                //                     { Id = t.id })
                //                     .SingleOrDefaultAsync();
                // if (idTipoComprobante == null)
                // {
                //     throw new Exception("Error: Tipo Comproante LIM no ha sido configurado");
                // };


                //  request.fechainicial = (request.fechainicial == null) ? DateTime.Now : request.fechainicial;
                //  request.fechafinal = (request.fechafinal == null) ? DateTime.Now : request.fechafinal;


                var entidadesDto = await _context.cntLiquidaImpuestos
                .Include(t => t.Tercero)
                .Include(ti => ti.TipoImpuesto)
                .Include(c=>c.Comprobante)
                .Include(co => co.Comprobante)
                .ThenInclude(tipoc => tipoc.TipoComprobante)
                .Include(co => co.Comprobante)
                .ThenInclude(dt => dt.ComprobanteDetalleComprobantes)
                .Include(co=>co.Comprobante)
                .ThenInclude(t=>t.Usuario)
                .ThenInclude(tu=>tu.Tercero)
                .Where(li=>li.Comprobante.CcoFecha>= request.fechainicial
                        &&li.Comprobante.CcoFecha <= request.fechafinal
                        && li.Comprobante.IdSucursal == request.id_sucursal
                        && li.Estado == "A")
                .Select(p => _mapper.Map<CntLiquidaImpuesto, ListarLiquidaImpuestosModel>(p))
                .ToListAsync();
              
                return entidadesDto;
            }
        }

    }
}