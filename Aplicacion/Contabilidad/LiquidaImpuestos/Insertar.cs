using MediatR;
using Persistencia;
using System;
using Dominio.Contabilidad;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;
using Aplicacion.Models.Contabilidad.LiquidaImpuestos;
using AutoMapper;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Aplicacion.Contabilidad.Comprobantes;
using Aplicacion.Models.Contabilidad.Comprobantes;

namespace Aplicacion.Contabilidad.LiquidaImpuestos
{
    public class Insertar
    {

        public class Ejecuta : InsertarLiquidaImpuestosModel, IRequest
        { }



        public class EjecutaValidador : AbstractValidator<Ejecuta>
        {
            public EjecutaValidador()
            {
                RuleFor(x => x.id_tipoimpuesto).NotEmpty();
                // RuleFor(x => x.id_comprobante).NotEmpty();
                // RuleFor(x => x.id_puc).NotEmpty();
                // RuleFor(x => x.IdTercero).NotEmpty();
                // RuleFor(x => x.id_sucursal).NotEmpty();
                // RuleFor(x => x.lim_fechainicial).NotEmpty();
                // RuleFor(x => x.lim_fechafinal).NotEmpty();
               // RuleFor(x => x.id_usuario).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly CntContext _context;
            private readonly IMapper _mapper;
            private IInsertarComprobante _insertarComprobante;



            public Manejador(CntContext context, IMapper mapper, IInsertarComprobante insertarComprobante)
            {
                _context = context;
                _mapper = mapper;
                _insertarComprobante = insertarComprobante;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {

                //Encontrar el id para el tipo de comprobante LIM para generar el comprobante contable
                var idTipoComprobante = await _context.cntTipoComprobantes
                                    .Where(t => t.Codigo == "LIM")
                                    .Select(t => new IdLiquidaImpuestoModel()
                                    { Id = t.Id })
                                    .SingleOrDefaultAsync();

                if (idTipoComprobante == null)
                {
                    throw new Exception("Error: Tipo Comproante LIM no encontrado");
                };

                var idTipoImpuesto = await _context.cntTipoImpuestos
                                    .Where(t => t.Id == request.id_tipoimpuesto)
                                    .Select(t => new IdLiquidaImpuestoModel()
                                    { Id = t.Id })
                                    .SingleOrDefaultAsync();

                if (idTipoImpuesto == null)
                {
                    throw new Exception("Error: Tipo Impuesto no encontrado");
                };



                var entidad = await _context.cntEntidades
                     .Where(e => e.Id == request.id_entidad && e.IdTipoimpuesto == request.id_tipoimpuesto)
                     .Select(e => new IdLiquidaImpuestoModel() { Id = e.IdTercero })
                     .FirstOrDefaultAsync();

                if (entidad == null)
                { throw new Exception("No se ha configurado correctamente la Entidad con su tipo de impuesto"); }

                var cuentaCierre = await _context.cntCuentaImpuestos
                    .Where(ci => ci.IdTipoimpuesto == request.id_tipoimpuesto)
                    .Select(ci => new IdLiquidaImpuestoModel() { Id = ci.IdPuc })
                    .FirstOrDefaultAsync();

                if (cuentaCierre == null)
                { throw new Exception("No se ha configurado la contrapartida para el tipo de Impuesto"); }

               
                //Generar saldos totalizados por tercero por cuenta.
                //Si el saldo es debito generamos movimiento al crédito a la cuenta recibida en request.id_puc 
                //y con el tercero request.IdTercero y Viceversa
                //Iniciar Transacción 
                //Add a detalleComprobante
                //Generar Comprobante 

                
               // var entidadComprobante = new InsertarComprobantesModel();
                //var entidadComprobante = _mapper.Map<InsertarComprobantesModel, CntComprobante>(request.comprobante);
                var idEntidadComprobante = _insertarComprobante.Insertar(request.comprobante);

                var entidadDto = _mapper.Map<InsertarLiquidaImpuestosModel, CntLiquidaImpuesto>(request);
                InsertarComprobantesModel  comprobante = new InsertarComprobantesModel()
                {

                    id_sucursal=request.id_sucursal,
                    id_tipocomprobante= idTipoComprobante.Id,
                    id_modulo = 2,
                    IdTercero = entidad.Id,
                    //cco_fecha=request.cco_fecha,
                    cco_documento=request.cco_documento,
                    cco_detalle = "Liquidación Automática de Cuentas por Tercero",
                    //id_usuario=request.id_usuario

                };
                var transaction = _context.Database.BeginTransaction();

                try
                {
                    var respuestacc = await _insertarComprobante.Insertar(comprobante);

                    transaction.Commit();
                    if(respuestacc.Id<0)
                      throw new Exception("Error al insertar Comprobante");
                    

                   // _context.cntLiquidaImpuestos.Add(entidadDto);

                    var respuesta = await _context.SaveChangesAsync();
                    if (respuesta > 0)
                    {
                        transaction.Commit();
                        return Unit.Value;
                    }

                    throw new Exception("Error al insertar LiquidaImpuesto");
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al Insertar registro catch " + ex.Message);

                }
            }
        }

    }
}