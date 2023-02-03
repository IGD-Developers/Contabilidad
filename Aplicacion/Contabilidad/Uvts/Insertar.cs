using Persistencia;
using Dominio.Contabilidad;
using MediatR;
using System;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;

namespace Aplicacion.Contabilidad.Uvts
{
    public class Insertar
    {
        public class Ejecuta: IRequest
        {

            public int uvt_ano { get; set; }
            public double uvt_valor { get; set; }
            public DateTime created_at { get; set; }
            public DateTime? updated_at { get; set; }

        }

        public class EjecutaValidador : AbstractValidator<Ejecuta>
        {
            public EjecutaValidador()
            {
                RuleFor(x=>x.uvt_ano).NotEmpty();
                RuleFor(x=>x.uvt_valor).NotEmpty();
        
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
                var uvt = new CntUvt
                {
                    UvtAno =  request.uvt_ano,
                    UvtValor = request.uvt_valor
                };

                context.cntUvts.Add(uvt);
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
