using Persistencia;
using System;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;

namespace Aplicacion.Contabilidad.FormatoColumnas
{
    public class Editar
    {
        public class Ejecuta:IRequest
        {

            public int Id { get; set; }
            public int id_exogenaformato { get; set; }
            public string fco_columna { get; set; }
            public string fco_campo { get; set; }
            public string fco_tipo { get; set; }
        }

        public class EjecutaValidador : AbstractValidator<Ejecuta>
        {
            public EjecutaValidador()
            {
                RuleFor(x=>x.Id).NotEmpty();
                RuleFor(x=>x.id_exogenaformato).NotEmpty();
                RuleFor(x=>x.fco_columna).NotEmpty();
                RuleFor(x=>x.fco_campo).NotEmpty();
                RuleFor(x=>x.fco_tipo).NotEmpty();
        
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

            var formatoColumna = await context.cntFormatoColumnas.FindAsync(request.Id);
            if (formatoColumna == null) {  
                throw new Exception("Registro no encontrado");
            };   
            formatoColumna.id_exogenaformato =request.id_exogenaformato;
            formatoColumna.fco_columna =request.fco_columna;;
            formatoColumna.fco_campo =request.fco_campo;;
            formatoColumna.fco_tipo =request.fco_tipo;

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


