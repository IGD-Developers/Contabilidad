using Persistencia;
using System;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;


namespace Aplicacion.Contabilidad.PucTipos
{
    public class Editar
    {
        public class Ejecuta: IRequest {
            public int Id { get; set; }
            public string Codigo { get; set; }
            public string Nombre { get; set; }

        }
        public class EjecutaValidador : AbstractValidator<Ejecuta>
        {
            public EjecutaValidador()
            {
                RuleFor(x=>x.Id).NotEmpty();
                RuleFor(x=>x.Codigo).NotEmpty();
                RuleFor(x=>x.Nombre).NotEmpty();
        
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

               var PucTipo = await context.cntPucTipos.FindAsync(request.Id);
               if (PucTipo == null) {  
                    throw new Exception("Registro no encontrado");
               };

                PucTipo.Codigo = request.Codigo;
                PucTipo.Nombre =request.Nombre;

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