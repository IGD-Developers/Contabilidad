using Persistencia;
using MediatR;
using Dominio.Contabilidad;
using System.Threading.Tasks;
using System.Threading;
using System;
using FluentValidation;

namespace Aplicacion.Contabilidad.TipoCuentas;

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


    public class Manejador: IRequestHandler<Ejecuta> {

        private readonly CntContext context;

        public Manejador(CntContext context)
        {
            this.context = context;
        }

        public async  Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
        {
            var TipoCuenta = new CntTipoCuenta 
            {
                Codigo = request.Codigo,
                Nombre = request.Nombre
            };

            context.cntTipoCuentas.Add(TipoCuenta);
            var respuesta=await context.SaveChangesAsync();
            if (respuesta>0)
            {
                return Unit.Value;
            }
            throw new Exception("Error 108 al insertar tipocuenta");
        }
    }

    
}