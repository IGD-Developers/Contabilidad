using Persistencia;
using System;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;


namespace Aplicacion.Contabilidad.DetalleComprobantes
{
    public class Editar
    {

        public class Ejecuta : IRequest {

            
            public int Id { get; set; }
            public int id_comprobante { get; set; }
            public int id_centrocosto { get; set; }
            public int id_puc { get; set; }
            public int IdTercero { get; set; }
            public double dco_base { get; set; }
            public double dco_tarifa { get; set; }
            public double dco_debito { get; set; }
            public double dco_credito { get; set; }
            public string dco_detalle { get; set; }
        }



public class EjecutaValidador : AbstractValidator<Ejecuta>
        {
            public EjecutaValidador()
            {
                RuleFor(x=>x.Id).NotEmpty();
                RuleFor(x=>x.id_comprobante).NotEmpty();
                RuleFor(x=>x.id_centrocosto).NotEmpty();
                RuleFor(x=>x.id_puc).NotEmpty();
                RuleFor(x=>x.IdTercero).NotEmpty();
                RuleFor(x=>x.dco_tarifa).NotEmpty();
                RuleFor(x=>x.dco_debito).NotEmpty();
                RuleFor(x=>x.dco_credito).NotEmpty();
                RuleFor(x=>x.dco_detalle).NotEmpty();
            }
        }  
            public class Manejador: IRequestHandler<Ejecuta>
        {
            private readonly CntContext context;

            public Manejador(CntContext context)
            {
                this.context = context;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var detalleComprobante = await context.cntDetalleComprobantes.FindAsync(request.Id);

                if (detalleComprobante == null) {
                    throw new Exception("Registro no encontrado");
                };

                    detalleComprobante.IdComprobante = request.id_comprobante;
                    detalleComprobante.IdCentrocosto= request.id_centrocosto;
                    detalleComprobante.IdPuc  = request.id_puc;
                    detalleComprobante.IdTercero  =request.IdTercero;
                    detalleComprobante.DcoBase =request.dco_base;
                    detalleComprobante.DcoTarifa = request.dco_tarifa;
                    detalleComprobante.DcoDebito = request.dco_tarifa;
                    detalleComprobante.DcoCredito = request.dco_credito;
                    detalleComprobante.DcoDetalle= request.dco_detalle;


                var resultado=  await context.SaveChangesAsync();
                if (resultado>0)
                {
                    return Unit.Value;
                }

                throw new Exception("Error al modificar registro");
 



            }
        }       
    }
}