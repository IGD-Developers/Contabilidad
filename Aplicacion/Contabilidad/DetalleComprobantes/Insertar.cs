using MediatR;
using Persistencia;
using Dominio.Contabilidad;
using System.Threading.Tasks;
using System.Threading;
using System;
using FluentValidation;

namespace Aplicacion.Contabilidad.DetalleComprobantes
{
    public class Insertar
    {
        public class Ejecuta : IRequest {

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
        public class Manejador: IRequestHandler<Ejecuta> {

            private readonly CntContext context;

            public Manejador(CntContext context)
            {
                this.context = context;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {

                var detalleComprobante = new CntDetalleComprobante
                {

                    IdComprobante = request.id_comprobante,
                    IdCentrocosto= request.id_centrocosto,
                    IdPuc  = request.id_puc,
                    IdTercero  =request.IdTercero,
                    DcoBase =request.dco_base,
                    DcoTarifa = request.dco_tarifa,
                    DcoDebito = request.dco_tarifa,
                    DcoCredito = request.dco_credito,
                    DcoDetalle= request.dco_detalle
                };
                
                context.cntDetalleComprobantes.Add(detalleComprobante);
                var respuesta = await context.SaveChangesAsync();
                if (respuesta>0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error 112 al insertar Detalle");
            }
        }
        
    }
}