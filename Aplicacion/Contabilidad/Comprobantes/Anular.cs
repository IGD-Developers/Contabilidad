using System;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.Models.Contabilidad.Comprobantes;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Contabilidad.Comprobantes;

public class Anular
{
    public class Ejecuta : IdComprobanteModel, IRequest
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
            .FirstOrDefaultAsync(cmp => cmp.Id == request.Id);

            if (Comprobante == null)
            {
                throw new Exception("Comprobante no encontrado");
            }

            if (Comprobante.TipoComprobante.Anulable == "F")
            {
                throw new Exception("El Tipo de Comprobante no permite Anulacion");
            }
            
            DateTime fechaGrabada= Comprobante.CcoFecha ?? DateTime.Now ;

            if (fechaGrabada.Month != DateTime.Now.Month  
                || fechaGrabada.Year != DateTime.Now.Year)
            {
                throw new Exception("Sólo puede Anular Comprobantes del mes actual");
            }


            try
            {
                Comprobante.Estado = "N";
                var resultado = await context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Anular registro catch " + ex.Message);


            }

            throw new Exception("Error al Anular Registro");
        }


    }

}