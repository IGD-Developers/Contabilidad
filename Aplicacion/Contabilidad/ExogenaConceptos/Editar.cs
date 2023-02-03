using Persistencia;
using System;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;

namespace Aplicacion.Contabilidad.ExogenaConceptos
{
    public class Editar
    {

        public class Ejecuta: IRequest
        {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
        }


        public class EjecutaValidador : AbstractValidator<Ejecuta>
        {
            public EjecutaValidador()
            {
                RuleFor(x=>x.Id).NotEmpty();
                RuleFor(x=>x.Codigo).NotEmpty();
                RuleFor(x=>x.Nombre).NotEmpty();
                RuleFor(x=>x.Estado).NotEmpty();
        
        
            }
        }    

        public  class Manejador: IRequestHandler<Ejecuta>
        {
            private readonly CntContext context;

            public Manejador(CntContext context)
            {
                this.context = context;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {

                 var exogenaConcepto = await context.cntExogenaConceptos.FindAsync(request.Id);
                if (exogenaConcepto == null) {  
                    throw new Exception("Registro no encontrado");
                };     
                exogenaConcepto.Codigo = request.Codigo;
                exogenaConcepto.Nombre = request.Nombre;
                exogenaConcepto.Estado = request.Estado;

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