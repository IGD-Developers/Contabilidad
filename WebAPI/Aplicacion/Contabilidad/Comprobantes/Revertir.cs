using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ContabilidadWebAPI.Dominio.Contabilidad;
using AutoMapper;
using System.Linq;
using ContabilidadWebAPI.Aplicacion.Contabilidad.Consecutivos;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Consecutivos;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Comprobantes;
using ContabilidadWebAPI.Persistencia;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Comprobantes;

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

        public Manejador(CntContext context, IMapper mapper, IInsertarConsecutivo insertarConsecutivo)
        {
            this.context = context;
            this.mapper = mapper;
            this.insertarConsecutivo = insertarConsecutivo;

        }

        public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
        {

            var Comprobante = await context.cntComprobantes
            .Include(t => t.TipoComprobante)
            .Include(d => d.ComprobanteDetalleComprobantes)
            .FirstOrDefaultAsync(cmp => cmp.Id == request.Id);


            if (Comprobante == null)
            {
                throw new Exception("Registro no encontrado");
            };

            if (Comprobante.TipoComprobante.Anulable == "F")
            {
                throw new Exception("El Tipo de Comprobante no permite Reversión ni Anulación");
            }

            if (Comprobante.Estado != "A")
            {
                throw new Exception("El Comprobante no está disponible para Revertir porque ha sido sometido algún proceso que cambió su Estado ");
            }

            //Fin insertra cr


            //Inicia Transaccion - Tiene AutoRollback:
            var transaction = context.Database.BeginTransaction();

            try
            {
                //Insertar Comprobante revertido cr

                //TODO: MARIA Parametrizar tipo de Comprobante RVD para reversion en la data de cnt_tipocomprobante. Por ahora lo identificamos con su Codigo :
                var tipoRever = await context.cntTipoComprobantes
                .Where(t => t.Codigo == "RVD")
                .Select(t => new CntTipoComprobante() { Id = t.Id })
                .FirstOrDefaultAsync();



                //   .Select(p =>new  ListarCuentaImpuestosModel()
                //                     {
                //                         PucNombre =p.puc.Nombre,
                //                         PucCodigo =p.puc.Codigo,
                //                         TipoImpuestoNombre=p.TipoImpuesto.Nombre,
                //                         TipoImpuestoCodigo=p.TipoImpuesto.Codigo
                //                     })



                // var tipoRever = await context.cntTipoComprobantes
                // .FirstOrDefaultAsync(t => t.Codigo == "RVD");




                ConsecutivoComprobanteModel cns = new ConsecutivoComprobanteModel
                {
                    IdTipocomprobante = tipoRever.Id,
                    Fecha = Convert.ToDateTime(Comprobante.CcoFecha),
                    IdSucursal = Comprobante.IdSucursal
                };
                var resu = await insertarConsecutivo.Insertar(cns);
                Console.WriteLine(resu);

                request.IdTipocomprobante = tipoRever.Id;
                request.CcoAno = resu.CoAno;
                request.CcoMes = resu.CoMes;
                request.CcoConsecutivo = resu.CoConsecutivo;


                var revertido = new CntComprobante
                {
                    IdSucursal = Comprobante.IdSucursal,
                    IdTipocomprobante = tipoRever.Id,
                    IdModulo = Comprobante.IdModulo,
                    IdTercero = Comprobante.IdTercero,
                    IdReversion = null,
                    CcoAno = resu.CoAno,
                    CcoMes = resu.CoMes,
                    CcoConsecutivo = resu.CoConsecutivo,
                    CcoFecha = Comprobante.CcoFecha,
                    CcoDocumento = Comprobante.CcoDocumento,
                    CcoDetalle = Comprobante.CcoDetalle,
                    Estado = "R",
                    IdUsuario = Comprobante.IdUsuario
                };



                await context.cntComprobantes.AddAsync(revertido);
                var respuesta = await context.SaveChangesAsync();
                int nuevoid = revertido.Id;
                Comprobante.IdReversion = nuevoid;
                Comprobante.Estado = "R";

                Console.WriteLine(nuevoid);
                foreach (var registro in Comprobante.ComprobanteDetalleComprobantes)
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