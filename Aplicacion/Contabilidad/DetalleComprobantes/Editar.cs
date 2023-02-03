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
            public int id_tercero { get; set; }
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
                RuleFor(x=>x.id_tercero).NotEmpty();
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

                    detalleComprobante.id_comprobante = request.id_comprobante;
                    detalleComprobante.id_centrocosto= request.id_centrocosto;
                    detalleComprobante.id_puc  = request.id_puc;
                    detalleComprobante.id_tercero  =request.id_tercero;
                    detalleComprobante.dco_base =request.dco_base;
                    detalleComprobante.dco_tarifa = request.dco_tarifa;
                    detalleComprobante.dco_debito = request.dco_tarifa;
                    detalleComprobante.dco_credito = request.dco_credito;
                    detalleComprobante.dco_detalle= request.dco_detalle;


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