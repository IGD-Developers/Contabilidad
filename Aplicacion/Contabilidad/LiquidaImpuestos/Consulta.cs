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

namespace Aplicacion.Contabilidad.LiquidaImpuestos;

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
            //                     .Where(t => t.Codigo == "LIM")
            //                     .Select(t => new IdLiquidaImpuestoModel()
            //                     { Id = t.Id })
            //                     .SingleOrDefaultAsync();
            // if (idTipoComprobante == null)
            // {
            //     throw new Exception("Error: Tipo Comproante LIM no ha sido configurado");
            // };


            //  request.FechaInicial = (request.FechaInicial == null) ? DateTime.Now : request.FechaInicial;
            //  request.FechaFinal = (request.FechaFinal == null) ? DateTime.Now : request.FechaFinal;


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
            .Where(li=>li.Comprobante.CcoFecha>= request.FechaInicial
                    &&li.Comprobante.CcoFecha <= request.FechaFinal
                    && li.Comprobante.IdSucursal == request.IdSucursal
                    && li.Estado == "A")
            .Select(p => _mapper.Map<CntLiquidaImpuesto, ListarLiquidaImpuestosModel>(p))
            .ToListAsync();
          
            return entidadesDto;
        }
    }

}