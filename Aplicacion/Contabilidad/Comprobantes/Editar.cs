using MediatR;
using Persistencia;
using Dominio.Contabilidad;
using System;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;
using Aplicacion.Models.Contabilidad.Comprobantes;
using AutoMapper;
using System.Linq;
using Aplicacion.Models.Contabilidad.DetalleComprobantes;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Contabilidad.Comprobantes
{
    public class Editar
    {
        public class Ejecuta : EditarComprobantesModel, IRequest

        { }


        public class EjecutaValidador : AbstractValidator<Ejecuta>
        {
            public EjecutaValidador()
            {
                // RuleFor(x => x.id_sucursal).NotEmpty();
                // RuleFor(x => x.id_tipocomprobante).NotEmpty();
                RuleFor(x => x.IdTercero).NotEmpty();
                // RuleFor(x => x.cco_ano).NotEmpty();
                // RuleFor(x => x.cco_mes).NotEmpty();
                // RuleFor(x => x.cco_consecutivo).NotEmpty();
                // RuleFor(x => x.cco_fecha).NotEmpty();
                RuleFor(x => x.cco_documento).NotEmpty();
                RuleFor(x => x.cco_detalle).NotEmpty();
                // RuleFor(x => x.id_usuario).NotEmpty();


            }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly CntContext context;
            private readonly IMapper _mapper;


            public Manejador(CntContext context, IMapper mapper)
            {
                this.context = context;
                _mapper = mapper;

            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                
                if (request.cco_fecha == null)
                {
                    throw new Exception("Fecha no válida");
                }

                var comprobante = await context.cntComprobantes
                .Include(t => t.TipoComprobante)
                .Include(d => d.ComprobanteDetalleComprobantes)
                .FirstOrDefaultAsync(cmp => cmp.Id == request.Id);


                if (comprobante == null)
                {
                    throw new Exception("Comprobante no encontrado");
                }

                if (comprobante.TipoComprobante.Editable == "F")
                {
                    throw new Exception("Comprobante no permite Edición");
                }

                if (comprobante.Estado != "A" )
                {
                    throw new Exception("El Comprobante no está disponible para Edición porque ha sido sometido algún proceso que cambió su Estado ");
                }

               var entidadDto = _mapper.Map<EditarComprobantesModel, CntComprobante>(request);
                if(entidadDto.Tcredito!=entidadDto.Tdebito)
                {
                    
                    throw new Exception("Los Débitos y Créditos no son iguales" );
                    //Console.WriteLine("Los Débitos y Créditos no son iguales" );

                }

                //var comprobantesDto = _mapper.Map<CntComprobante,InsertarComprobantesModel>(request);

                //Inicia Transaccion - Tiene AutoRollback
                var transaction = context.Database.BeginTransaction();

                try
                {
                    comprobante.IdModulo = request.id_modulo ?? comprobante.IdModulo;
                    comprobante.IdTercero = request.IdTercero ?? comprobante.IdTercero;
                    comprobante.CcoDocumento = request.cco_documento ?? comprobante.CcoDocumento;
                    comprobante.CcoDetalle = request.cco_detalle ?? comprobante.CcoDetalle;
                    comprobante.CcoFecha = request.cco_fecha ?? comprobante.CcoFecha;



                    if (request.comprobanteDetalleComprobantes != null)
                    {
                        if (request.comprobanteDetalleComprobantes.Count > 0)
                        {
                            /*Eliminar detalles de comprobante*/
                            var detalles =  await context.cntDetalleComprobantes
                                .Where(x => x.IdComprobante == request.Id)
                                .ToListAsync();

                            //var detalles = comprobante.comprobanteDetalleComprobantes;
                            
                            //context.Cities.RemoveRange(cities);
                           context.RemoveRange(detalles);
                            
                            // foreach (var registro in detalles)
                            // {
                            //     context.cntDetalleComprobantes.Remove(registro);
                            // }
                            /*Fin del procedimiento para eliminar detalles*/



                            foreach (var detalle in request.comprobanteDetalleComprobantes)
                            {
                                var nuevoDetalle = new CntDetalleComprobante
                                {

                                    IdComprobante = request.Id,
                                    IdCentrocosto = detalle.id_centrocosto,
                                    IdPuc = detalle.id_puc,
                                    IdTercero = detalle.IdTercero,
                                    DcoBase = detalle.dco_base,
                                    DcoTarifa = detalle.dco_tarifa,
                                    DcoDebito = detalle.dco_debito,
                                    DcoCredito = detalle.dco_credito,
                                    DcoDetalle = detalle.dco_detalle
                                };
                                await context.cntDetalleComprobantes.AddAsync(nuevoDetalle);
                            }

                            /*Fin del procedimiento*/
                        }
                    }

                    var resultado = await context.SaveChangesAsync();


                    if (resultado > 0)
                    {
                        transaction.Commit();
                        return Unit.Value;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al Modificar registro catch " + ex.Message);


                }

                throw new Exception("Error al Modificar Registro");
            }


        }
    }


}