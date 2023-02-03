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

            public int IdComprobante { get; set; }
            public int IdCentrocosto { get; set; }
            public int IdPuc { get; set; }
            public int IdTercero { get; set; }
            public double DcoBase { get; set; }
            public double DcoTarifa { get; set; }
            public double DcoDebito { get; set; }
            public double DcoCredito { get; set; }
            public string DcoDetalle { get; set; }
        }
public class EjecutaValidador : AbstractValidator<Ejecuta>
        {
            public EjecutaValidador()
            {
                RuleFor(x=>x.IdComprobante).NotEmpty();
                RuleFor(x=>x.IdCentrocosto).NotEmpty();
                RuleFor(x=>x.IdPuc).NotEmpty();
                RuleFor(x=>x.IdTercero).NotEmpty();
                RuleFor(x=>x.DcoTarifa).NotEmpty();
                RuleFor(x=>x.DcoDebito).NotEmpty();
                RuleFor(x=>x.DcoCredito).NotEmpty();
                RuleFor(x=>x.DcoDetalle).NotEmpty();
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

                    IdComprobante = request.IdComprobante,
                    IdCentrocosto= request.IdCentrocosto,
                    IdPuc  = request.IdPuc,
                    IdTercero  =request.IdTercero,
                    DcoBase =request.DcoBase,
                    DcoTarifa = request.DcoTarifa,
                    DcoDebito = request.DcoTarifa,
                    DcoCredito = request.DcoCredito,
                    DcoDetalle= request.DcoDetalle
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