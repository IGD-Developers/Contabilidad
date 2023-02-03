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
                .Include(t => t.tercero)
                .Include(ti => ti.tipoImpuesto)
                .Include(c=>c.comprobante)
                .Include(co => co.comprobante)
                .ThenInclude(tipoc => tipoc.tipoComprobante)
                .Include(co => co.comprobante)
                .ThenInclude(dt => dt.comprobanteDetalleComprobantes)
                .Include(co=>co.comprobante)
                .ThenInclude(t=>t.usuario)
                .ThenInclude(tu=>tu.tercero)
                .Where(li=>li.comprobante.cco_fecha>= request.fechainicial
                        &&li.comprobante.cco_fecha<= request.fechafinal
                        && li.comprobante.id_sucursal == request.id_sucursal
                        && li.estado == "A")
                .Select(p => _mapper.Map<CntLiquidaImpuesto, ListarLiquidaImpuestosModel>(p))
                .ToListAsync();
              
                return entidadesDto;
            }
        }

    }
}