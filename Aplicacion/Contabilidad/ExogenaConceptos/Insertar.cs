using Dominio.Contabilidad;
using Persistencia;
using System;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;

namespace Aplicacion.Contabilidad.ExogenaConceptos
{
    public class Insertar
    {
        public class Ejecuta: IRequest
        {
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string estado { get; set; }
        }


       public class EjecutaValidador : AbstractValidator<Ejecuta>
        {
            public EjecutaValidador()
            {
                RuleFor(x=>x.codigo).NotEmpty();
                RuleFor(x=>x.nombre).NotEmpty();
                RuleFor(x=>x.estado).NotEmpty();
        
        
            }
        }    
        public class Manejador:IRequestHandler<Ejecuta>
        {

            private readonly CntContext context;

            public Manejador(CntContext context)
            {
                this.context = context;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {

                var exogenaConcepto = new CntExogenaConcepto
                {
                    Codigo = request.codigo,
                    Nombre = request.nombre,
                    Estado = request.estado

                };
                context.cntExogenaConceptos.Add(exogenaConcepto);
                var respuesta =  await context.SaveChangesAsync();
                if (respuesta > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al insertar ExogenaConcepto");
            }
        }
        
    }
}