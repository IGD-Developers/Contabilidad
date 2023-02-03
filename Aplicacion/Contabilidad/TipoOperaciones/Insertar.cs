using Persistencia;
using Dominio.Contabilidad;
using MediatR;
using System;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;

namespace Aplicacion.Contabilidad.TipoOperaciones
{
    public class Insertar

    {

        public class Ejecuta: IRequest
        {

            public string codigo { get; set; }
            public string nombre { get; set; }
            public string formula { get; set; }

        }

        public class EjecutaValidador : AbstractValidator<Ejecuta>
        {
            public EjecutaValidador()
            {
                RuleFor(x=>x.codigo).NotEmpty();
                RuleFor(x=>x.nombre).NotEmpty();
        
            }
        }    


        public class Manejador: IRequestHandler<Ejecuta>
        {

            private readonly CntContext context;

            public Manejador(CntContext context)
            {
                this.context = context;
            }

        public class EjecutaValidador : AbstractValidator<Ejecuta>
        {
            public EjecutaValidador()
            {
                RuleFor(x=>x.codigo).NotEmpty();
                RuleFor(x=>x.nombre).NotEmpty();
        
            }
        }    


            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {

                var tipoOperacion = new CntTipoOperacion
                {
                    codigo = request.codigo,
                    nombre = request.nombre,
                    formula = request.formula ?? ""

                };
                

                context.cntTipoOperaciones.Add(tipoOperacion);
                var respuesta = await context.SaveChangesAsync();
                if (respuesta > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("Error al insertar TipoOperacion");
            }
        }
        
    }
}