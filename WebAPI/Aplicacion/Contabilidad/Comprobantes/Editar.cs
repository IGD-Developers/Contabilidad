using MediatR;
using ContabilidadWebAPI.Dominio.Contabilidad;
using System;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;
using AutoMapper;
using System.Linq;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.DetalleComprobantes;
using Microsoft.EntityFrameworkCore;
using ContabilidadWebAPI.Persistencia;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Comprobantes;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Comprobantes;

public class Editar
{
    public class Ejecuta : EditarComprobantesModel, IRequest

    { }


    public class EjecutaValidador : AbstractValidator<Ejecuta>
    {
        public EjecutaValidador()
        {
            // RuleFor(x => x.IdSucursal).NotEmpty();
            // RuleFor(x => x.IdTipocomprobante).NotEmpty();
            RuleFor(x => x.IdTercero).NotEmpty();
            // RuleFor(x => x.CcoAno).NotEmpty();
            // RuleFor(x => x.CcoMes).NotEmpty();
            // RuleFor(x => x.CcoConsecutivo).NotEmpty();
            // RuleFor(x => x.CcoFecha).NotEmpty();
            RuleFor(x => x.CcoDocumento).NotEmpty();
            RuleFor(x => x.CcoDetalle).NotEmpty();
            // RuleFor(x => x.IdUsuario).NotEmpty();


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

            if (request.CcoFecha == null)
            {
                throw new Exception("Fecha no válida");
            }

            var Comprobante = await context.cntComprobantes
            .Include(t => t.TipoComprobante)
            .Include(d => d.ComprobanteDetalleComprobantes)
            .FirstOrDefaultAsync(cmp => cmp.Id == request.Id);


            if (Comprobante == null)
            {
                throw new Exception("Comprobante no encontrado");
            }

            if (Comprobante.TipoComprobante.Editable == "F")
            {
                throw new Exception("Comprobante no permite Edición");
            }

            if (Comprobante.Estado != "A")
            {
                throw new Exception("El Comprobante no está disponible para Edición porque ha sido sometido algún proceso que cambió su Estado ");
            }

            var entidadDto = _mapper.Map<EditarComprobantesModel, CntComprobante>(request);
            if (entidadDto.Tcredito != entidadDto.Tdebito)
            {

                throw new Exception("Los Débitos y Créditos no son iguales");
                //Console.WriteLine("Los Débitos y Créditos no son iguales" );

            }

            //var comprobantesDto = _mapper.Map<CntComprobante,InsertarComprobantesModel>(request);

            //Inicia Transaccion - Tiene AutoRollback
            var transaction = context.Database.BeginTransaction();

            try
            {
                Comprobante.IdModulo = request.IdModulo ?? Comprobante.IdModulo;
                Comprobante.IdTercero = request.IdTercero ?? Comprobante.IdTercero;
                Comprobante.CcoDocumento = request.CcoDocumento ?? Comprobante.CcoDocumento;
                Comprobante.CcoDetalle = request.CcoDetalle ?? Comprobante.CcoDetalle;
                Comprobante.CcoFecha = request.CcoFecha ?? Comprobante.CcoFecha;



                if (request.ComprobanteDetalleComprobantes != null)
                {
                    if (request.ComprobanteDetalleComprobantes.Count > 0)
                    {
                        /*Eliminar detalles de Comprobante*/
                        var detalles = await context.cntDetalleComprobantes
                            .Where(x => x.IdComprobante == request.Id)
                            .ToListAsync();

                        //var detalles = Comprobante.ComprobanteDetalleComprobantes;

                        //context.Cities.RemoveRange(cities);
                        context.RemoveRange(detalles);

                        // foreach (var registro in detalles)
                        // {
                        //     context.cntDetalleComprobantes.Remove(registro);
                        // }
                        /*Fin del procedimiento para eliminar detalles*/



                        foreach (var detalle in request.ComprobanteDetalleComprobantes)
                        {
                            var nuevoDetalle = new CntDetalleComprobante
                            {

                                IdComprobante = request.Id,
                                IdCentrocosto = detalle.IdCentrocosto,
                                IdPuc = detalle.IdPuc,
                                IdTercero = detalle.IdTercero,
                                DcoBase = detalle.DcoBase,
                                DcoTarifa = detalle.DcoTarifa,
                                DcoDebito = detalle.DcoDebito,
                                DcoCredito = detalle.DcoCredito,
                                DcoDetalle = detalle.DcoDetalle
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