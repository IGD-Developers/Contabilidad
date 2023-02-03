using Persistencia;
using System;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;


namespace Aplicacion.Contabilidad.FormatoConceptos;

public class Editar
{

    public class Ejecuta: IRequest
    {
    public int Id { get; set; }
    public int id_exogenaformato { get; set; }
    public int id_exogenaconcepto { get; set; }

    }

    public class EjecutaValidador : AbstractValidator<Ejecuta>
    {
        public EjecutaValidador()
        {
            RuleFor(x=>x.Id).NotEmpty();
            RuleFor(x=>x.id_exogenaformato).NotEmpty();
            RuleFor(x=>x.id_exogenaconcepto).NotEmpty();
    
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

            var formatoConcepto = await context.cntFormatoConceptos.FindAsync(request.Id);
           if (formatoConcepto == null) {  
                throw new Exception("Registro no encontrado");
            };       

            formatoConcepto.IdExogenaformato = request.id_exogenaformato;
            formatoConcepto.IdExogenaconcepto = request.id_exogenaconcepto;

            var resultado=  await context.SaveChangesAsync();
            if (resultado>0)
            {
                return Unit.Value;
            }

            throw new Exception("Error al modificar registro");

        }
    }

}