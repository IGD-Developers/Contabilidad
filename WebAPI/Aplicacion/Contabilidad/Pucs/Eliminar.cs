using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using FluentValidation;
using ContabilidadWebAPI.Persistencia;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Pucs;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Pucs;

public class Eliminar
{
    public class Ejecuta : IdPucModel, IRequest
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
            var puc = await context.cntPucs.FindAsync(request.Id);
            if (puc == null)
            {
                throw new Exception("Registro no encontrado");
            };

            context.cntPucs.Remove(puc);

            try
            {
                var respuesta = await context.SaveChangesAsync();
                if (respuesta > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("Error Eliminar registro ");
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar registro catch " + ex.Message);
            }
        }

    }
}