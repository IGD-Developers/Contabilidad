using Persistencia;
using System;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;


namespace Aplicacion.Contabilidad.ExogenaFormatos;

public class Editar
{

     public class Ejecuta:IRequest
    {
        public int Id { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
    }

    public class EjecutaValidador : AbstractValidator<Ejecuta>
    {
        public EjecutaValidador()
        {
            RuleFor(x=>x.Id).NotEmpty();
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

        public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
        {
            var exogenaFormato = await context.cntExogenaFormatos.FindAsync(request.Id);
            if (exogenaFormato == null) {  
                throw new Exception("Registro no encontrado");
            };         
            exogenaFormato.codigo = request.nombre;
            exogenaFormato.nombre= request.nombre;              
            var resultado=  await context.SaveChangesAsync();
            if (resultado>0)
            {
                return Unit.Value;
            }

            throw new Exception("Error al modificar registro");

        }
    }

    
}