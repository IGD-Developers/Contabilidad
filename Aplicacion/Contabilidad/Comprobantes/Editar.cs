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

namespace Aplicacion.Contabilidad.Comprobantes;

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
            RuleFor(x => x.id_tercero).NotEmpty();
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
            .Include(t => t.tipoComprobante)
            .Include(d => d.comprobanteDetalleComprobantes)
            .FirstOrDefaultAsync(cmp => cmp.id == request.Id);


            if (comprobante == null)
            {
                throw new Exception("Comprobante no encontrado");
            }

            if (comprobante.tipoComprobante.editable == "F")
            {
                throw new Exception("Comprobante no permite Edición");
            }

            if (comprobante.estado != "A" )
            {
                throw new Exception("El Comprobante no está disponible para Edición porque ha sido sometido algún proceso que cambió su Estado ");
            }

           var entidadDto = _mapper.Map<EditarComprobantesModel, CntComprobante>(request);
            if(entidadDto.tcredito!=entidadDto.tdebito)
            {
                
                throw new Exception("Los Débitos y Créditos no son iguales" );
                //Console.WriteLine("Los Débitos y Créditos no son iguales" );

            }

            //var comprobantesDto = _mapper.Map<CntComprobante,InsertarComprobantesModel>(request);

            //Inicia Transaccion - Tiene AutoRollback
            var transaction = context.Database.BeginTransaction();

            try
            {
                comprobante.id_modulo = request.id_modulo ?? comprobante.id_modulo;
                comprobante.id_tercero = request.id_tercero ?? comprobante.id_tercero;
                comprobante.cco_documento = request.cco_documento ?? comprobante.cco_documento;
                comprobante.cco_detalle = request.cco_detalle ?? comprobante.cco_detalle;
                comprobante.cco_fecha = request.cco_fecha ?? comprobante.cco_fecha;



                if (request.comprobanteDetalleComprobantes != null)
                {
                    if (request.comprobanteDetalleComprobantes.Count > 0)
                    {
                        /*Eliminar detalles de comprobante*/
                        var detalles =  await context.cntDetalleComprobantes
                            .Where(x => x.id_comprobante == request.Id)
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

                                id_comprobante = request.Id,
                                id_centrocosto = detalle.id_centrocosto,
                                id_puc = detalle.id_puc,
                                id_tercero = detalle.id_tercero,
                                dco_base = detalle.dco_base,
                                dco_tarifa = detalle.dco_tarifa,
                                dco_debito = detalle.dco_debito,
                                dco_credito = detalle.dco_credito,
                                dco_detalle = detalle.dco_detalle
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