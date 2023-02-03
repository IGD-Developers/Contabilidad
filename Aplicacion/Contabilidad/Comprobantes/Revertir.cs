using System;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.Models.Contabilidad.Comprobantes;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;
using Dominio.Contabilidad;
using AutoMapper;
using Aplicacion.Models.Contabilidad.Consecutivos;
using Aplicacion.Contabilidad.Consecutivos;
using System.Linq;

namespace Aplicacion.Contabilidad.Comprobantes
{
    public class Revertir
    {
        public class Ejecuta : RevertirComprobantesModel, IRequest 
        { }

        public class EjecutaValidador : AbstractValidator<Ejecuta>
        {
            public EjecutaValidador()
            {
                //RuleFor(x => x.Id).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly CntContext context;
            private readonly IMapper mapper;
            private IInsertarConsecutivo insertarConsecutivo;

            public Manejador(CntContext context, IMapper mapper,IInsertarConsecutivo insertarConsecutivo)
            {
                this.context = context;
                this.mapper = mapper;
                this.insertarConsecutivo = insertarConsecutivo;

            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {

                var comprobante = await context.cntComprobantes
                .Include(t => t.TipoComprobante)
                .Include(d => d.ComprobanteDetalleComprobantes)
                .FirstOrDefaultAsync(cmp => cmp.Id == request.Id);


                if (comprobante == null)
                {
                    throw new Exception("Registro no encontrado");
                };

                if (comprobante.TipoComprobante.Anulable == "F")
                {
                    throw new Exception("El Tipo de Comprobante no permite Reversión ni Anulación");
                }

                 if (comprobante.Estado != "A" )
                {
                    throw new Exception("El Comprobante no está disponible para Revertir porque ha sido sometido algún proceso que cambió su Estado ");
                }

                //Fin insertra cr


                //Inicia Transaccion - Tiene AutoRollback:
                var transaction = context.Database.BeginTransaction();

                try
                {
                    //Insertar comprobante revertido cr

                    //TODO: MARIA Parametrizar tipo de comprobante RVD para reversion en la data de cnt_tipocomprobante. Por ahora lo identificamos con su codigo :
                    var tipoRever = await context.cntTipoComprobantes
                    .Where(t=>t.Codigo=="RVD")
                    .Select(t=> new CntTipoComprobante(){Id=t.Id})
                    .FirstOrDefaultAsync();
                    


                  //   .Select(p =>new  ListarCuentaImpuestosModel()
                //                     {
                //                         pucnombre =p.puc.nombre,
                //                         puccodigo =p.puc.codigo,
                //                         tipoimpuestonombre=p.tipoImpuesto.nombre,
                //                         tipoimpuestocodigo=p.tipoImpuesto.codigo
                //                     })
                    


                    // var tipoRever = await context.cntTipoComprobantes
                    // .FirstOrDefaultAsync(t => t.codigo == "RVD");

                   


                    ConsecutivoComprobanteModel cns = new ConsecutivoComprobanteModel
                    {
                        id_tipocomprobante = tipoRever.Id,
                        fecha = Convert.ToDateTime(comprobante.CcoFecha),
                        id_sucursal = comprobante.IdSucursal
                    };
                    var resu = await insertarConsecutivo.Insertar(cns);
                    System.Console.WriteLine(resu);

                    request.id_tipocomprobante=tipoRever.Id;
                    request.cco_ano = resu.CoAno;
                    request.cco_mes = resu.CoMes;
                    request.cco_consecutivo = resu.CoConsecutivo;

                    
                    var revertido = new CntComprobante
                    {
                        IdSucursal = comprobante.IdSucursal,
                        IdTipocomprobante = tipoRever.Id,
                        IdModulo = comprobante.IdModulo,
                        IdTercero = comprobante.IdTercero,
                        IdReversion = null,
                        CcoAno = resu.CoAno,
                        CcoMes = resu.CoMes,
                        CcoConsecutivo = resu.CoConsecutivo,
                        CcoFecha = comprobante.CcoFecha,
                        CcoDocumento = comprobante.CcoDocumento,
                        CcoDetalle = comprobante.CcoDetalle,
                        Estado = "R",
                        IdUsuario = comprobante.IdUsuario
                    };



                    await context.cntComprobantes.AddAsync(revertido);
                    var respuesta = await context.SaveChangesAsync();
                    int nuevoid = revertido.Id;
                    comprobante.IdReversion = nuevoid;
                    comprobante.Estado = "R";

                    Console.WriteLine(nuevoid);
                    foreach (var registro in comprobante.ComprobanteDetalleComprobantes)
                    {

                        var detalles = new CntDetalleComprobante
                        {
                            IdComprobante = nuevoid,
                            IdCentrocosto = registro.IdCentrocosto,
                            IdPuc = registro.IdPuc,
                            IdTercero = registro.IdTercero,
                            DcoBase = registro.DcoBase,
                            DcoTarifa = registro.DcoTarifa,
                            DcoDebito = registro.DcoCredito,
                            DcoCredito = registro.DcoDebito,
                            DcoDetalle = registro.DcoDetalle
                        };
                        await context.cntDetalleComprobantes.AddAsync(detalles);

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
                    throw new Exception("Error al Revertir Comprobante catch " + ex.Message);


                }

                throw new Exception("Error al Revertir Comprobante");



            }


        }
    }
}