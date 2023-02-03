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

namespace Aplicacion.Contabilidad.Comprobantes;

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
            .Include(t => t.tipoComprobante)
            .Include(d => d.comprobanteDetalleComprobantes)
            .FirstOrDefaultAsync(cmp => cmp.id == request.Id);


            if (comprobante == null)
            {
                throw new Exception("Registro no encontrado");
            };

            if (comprobante.tipoComprobante.anulable == "F")
            {
                throw new Exception("El Tipo de Comprobante no permite Reversión ni Anulación");
            }

             if (comprobante.estado != "A" )
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
                .Where(t=>t.codigo=="RVD")
                .Select(t=> new CntTipoComprobante(){id=t.id})
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
                    id_tipocomprobante = tipoRever.id,
                    fecha = Convert.ToDateTime(comprobante.cco_fecha),
                    id_sucursal = comprobante.id_sucursal
                };
                var resu = await insertarConsecutivo.Insertar(cns);
                System.Console.WriteLine(resu);

                request.id_tipocomprobante=tipoRever.id;
                request.cco_ano = resu.co_ano;
                request.cco_mes = resu.co_mes;
                request.cco_consecutivo = resu.co_consecutivo;

                
                var revertido = new CntComprobante
                {
                    id_sucursal = comprobante.id_sucursal,
                    id_tipocomprobante = tipoRever.id,
                    id_modulo = comprobante.id_modulo,
                    id_tercero = comprobante.id_tercero,
                    id_reversion = null,
                    cco_ano = resu.co_ano,
                    cco_mes = resu.co_mes,
                    cco_consecutivo = resu.co_consecutivo,
                    cco_fecha = comprobante.cco_fecha,
                    cco_documento = comprobante.cco_documento,
                    cco_detalle = comprobante.cco_detalle,
                    estado = "R",
                    id_usuario = comprobante.id_usuario
                };



                await context.cntComprobantes.AddAsync(revertido);
                var respuesta = await context.SaveChangesAsync();
                int nuevoid = revertido.id;
                comprobante.id_reversion = nuevoid;
                comprobante.estado = "R";

                Console.WriteLine(nuevoid);
                foreach (var registro in comprobante.comprobanteDetalleComprobantes)
                {

                    var detalles = new CntDetalleComprobante
                    {
                        id_comprobante = nuevoid,
                        id_centrocosto = registro.id_centrocosto,
                        id_puc = registro.id_puc,
                        id_tercero = registro.id_tercero,
                        dco_base = registro.dco_base,
                        dco_tarifa = registro.dco_tarifa,
                        dco_debito = registro.dco_credito,
                        dco_credito = registro.dco_debito,
                        dco_detalle = registro.dco_detalle
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