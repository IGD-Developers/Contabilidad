using Dominio.Contabilidad;
using Persistencia;
using System;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;

namespace Aplicacion.Contabilidad.ExogenaConceptos;

public class Insertar
{
    public class Ejecuta: IRequest
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
    }


   public class EjecutaValidador : AbstractValidator<Ejecuta>
    {
        public EjecutaValidador()
        {
            RuleFor(x=>x.Codigo).NotEmpty();
            RuleFor(x=>x.Nombre).NotEmpty();
            RuleFor(x=>x.Estado).NotEmpty();
    
    
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
                Codigo = request.Codigo,
                Nombre = request.Nombre,
                Estado = request.Estado

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