using System;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.Models.Contabilidad.Comprobantes;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Contabilidad.Comprobantes
{
    public class Eliminar
    {
        
        public class Ejecuta : EliminarComprobantesModel, IRequest
        { }

        public class EjecutaValidador : AbstractValidator<Ejecuta>
        {
            public EjecutaValidador()
            {
                RuleFor(x => x.Id).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly CntContext context;

            public Manejador(CntContext context)
            {
                this.context = context;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
               var Comprobante = await context.cntComprobantes
                .Include(t => t.TipoComprobante)
                .Include(d => d.ComprobanteDetalleComprobantes)
                .FirstOrDefaultAsync(cmp => cmp.Id == request.Id);

                if (Comprobante == null)
                {
                    throw new Exception("Comprobante no encontrado");
                }

                if (Comprobante.TipoComprobante.Borrable == "F")
                {
                    throw new Exception("El Tipo de Comprobante no permite Eliminación");
                }

                if (Comprobante.Estado != "A" )
                {
                    throw new Exception("El Comprobante no está disponible para Eliminación porque ha sido sometido algún proceso que cambió su Estado ");
                }
                
                //Inicia Transaccion - Tiene AutoRollback:
                var transaction = context.Database.BeginTransaction();
                
                try
                {
                    context.cntComprobantes.Remove(Comprobante);
                    
                    foreach (var registro in Comprobante.ComprobanteDetalleComprobantes)
                    {

                        context.cntDetalleComprobantes.Remove(registro);
                        
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
                    throw new Exception("Error al Eliminar registro catch " + ex.Message);


                }

                throw new Exception("Error al Eliminar Registro");
            }


        }

    }
   
}