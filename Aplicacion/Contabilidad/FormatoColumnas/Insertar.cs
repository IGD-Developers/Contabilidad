using Persistencia;
using Dominio.Contabilidad;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using FluentValidation;

namespace Aplicacion.Contabilidad.FormatoColumnas;

public class Insertar
{
    public class Ejecuta:IRequest
    {

        public int id_exogenaformato { get; set; }
        public string fco_columna { get; set; }
        public string fco_campo { get; set; }
        public string fco_tipo { get; set; }
    }

        public class EjecutaValidador : AbstractValidator<Ejecuta>
        {
        public EjecutaValidador()
        {
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
            var formatoColumna=new CntFormatoColumna
            {
                    id_exogenaformato =request.id_exogenaformato,
                    fco_columna =request.fco_columna,
                    fco_campo =request.fco_campo,
                    fco_tipo =request.fco_tipo
            };
            context.cntFormatoColumnas.Add(formatoColumna);
            var respuesta = await context.SaveChangesAsync();
            if (respuesta>0)
            {
                return Unit.Value;
            }

            throw new Exception("Error 113 al insertar Formato Columna");
        }
    }

    
    
}