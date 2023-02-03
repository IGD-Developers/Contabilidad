using Persistencia;
using Dominio.Contabilidad;
using MediatR;
using System;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;

namespace Aplicacion.Contabilidad.PucTipos;

public class Insertar
{

    public class Ejecuta: IRequest {
        public string Codigo { get; set; }
        public string Nombre { get; set; }

    }

    public class EjecutaValidador : AbstractValidator<Ejecuta>
    {
        public EjecutaValidador()
        {
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
            var PucTipo = new CntPucTipo
            {
                Codigo = request.Codigo,
                Nombre =request.Nombre
            };
            context.cntPucTipos.Add(PucTipo);
            var respuesta = await context.SaveChangesAsync();
            if (respuesta>0)
                {
                    return Unit.Value;
                }
                
            throw new Exception("Error 107 al insertar en PucTipo");
        }
    }

}