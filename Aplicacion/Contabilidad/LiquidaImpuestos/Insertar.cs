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
                RuleFor(x => x.IdTipoimpuesto).NotEmpty();
                // RuleFor(x => x.IdComprobante).NotEmpty();
                // RuleFor(x => x.IdPuc).NotEmpty();
                // RuleFor(x => x.IdTercero).NotEmpty();
                // RuleFor(x => x.IdSucursal).NotEmpty();
                // RuleFor(x => x.LimFechainicial).NotEmpty();
                // RuleFor(x => x.LimFechafinal).NotEmpty();
               // RuleFor(x => x.IdUsuario).NotEmpty();
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

                //Encontrar el Id para el tipo de Comprobante LIM para generar el Comprobante contable
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
                                    .Where(t => t.Id == request.IdTipoimpuesto)
                                    .Select(t => new IdLiquidaImpuestoModel()
                                    { Id = t.Id })
                                    .SingleOrDefaultAsync();

                if (idTipoImpuesto == null)
                {
                    throw new Exception("Error: Tipo Impuesto no encontrado");
                };



                var entidad = await _context.cntEntidades
                     .Where(e => e.Id == request.IdEntidad && e.IdTipoimpuesto == request.IdTipoimpuesto)
                     .Select(e => new IdLiquidaImpuestoModel() { Id = e.IdTercero })
                     .FirstOrDefaultAsync();

                if (entidad == null)
                { throw new Exception("No se ha configurado correctamente la Entidad con su tipo de impuesto"); }

                var cuentaCierre = await _context.cntCuentaImpuestos
                    .Where(ci => ci.IdTipoimpuesto == request.IdTipoimpuesto)
                    .Select(ci => new IdLiquidaImpuestoModel() { Id = ci.IdPuc })
                    .FirstOrDefaultAsync();

                if (cuentaCierre == null)
                { throw new Exception("No se ha configurado la contrapartida para el tipo de Impuesto"); }

               
                //Generar saldos totalizados por Tercero por Cuenta.
                //Si el saldo es debito generamos movimiento al crédito a la Cuenta recibida en request.IdPuc 
                //y con el Tercero request.IdTercero y Viceversa
                //Iniciar Transacción 
                //Add a detalleComprobante
                //Generar Comprobante 

                
               // var entidadComprobante = new InsertarComprobantesModel();
                //var entidadComprobante = _mapper.Map<InsertarComprobantesModel, CntComprobante>(request.Comprobante);
                var idEntidadComprobante = _insertarComprobante.Insertar(request.Comprobante);

                var entidadDto = _mapper.Map<InsertarLiquidaImpuestosModel, CntLiquidaImpuesto>(request);
                InsertarComprobantesModel  Comprobante = new InsertarComprobantesModel()
                {

                    IdSucursal=request.IdSucursal,
                    IdTipocomprobante= idTipoComprobante.Id,
                    IdModulo = 2,
                    IdTercero = entidad.Id,
                    //CcoFecha=request.CcoFecha,
                    CcoDocumento=request.CcoDocumento,
                    CcoDetalle = "Liquidación Automática de Cuentas por Tercero",
                    //IdUsuario=request.IdUsuario

                };
                var transaction = _context.Database.BeginTransaction();

                try
                {
                    var respuestacc = await _insertarComprobante.Insertar(Comprobante);

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