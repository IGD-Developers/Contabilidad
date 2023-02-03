using Dominio.Contabilidad;
using Persistencia;
using System;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;

namespace Aplicacion.Contabilidad.FormatoConceptos
{
    public class Insertar
    {

        public class Ejecuta: IRequest
        {

        public int id_exogenaformato { get; set; }
        public int id_exogenaconcepto { get; set; }

        }

        public class EjecutaValidador : AbstractValidator<Ejecuta>
        {
            public EjecutaValidador()
            {
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

                var formatoConcepto = new CntFormatoConcepto
                {
                    id_exogenaformato = request.id_exogenaformato,
                    id_exogenaconcepto = request.id_exogenaconcepto
                };

                context.cntFormatoConceptos.Add(formatoConcepto);
                var respuesta= await context.SaveChangesAsync();
                if (respuesta>0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al insertar FormatoConcepto");
            }
        }
        
    }
}