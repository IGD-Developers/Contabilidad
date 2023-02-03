using Persistencia;
using System;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;


namespace Aplicacion.Contabilidad.Uvts;

public class Editar
{

     public class Ejecuta: IRequest
    {

        public int Id { get; set; }
        public int uvt_ano { get; set; }
        public double uvt_valor { get; set; }
        public DateTime created_at { get; set; }
        public DateTime? updated_at { get; set; }

    }

    public class EjecutaValidador : AbstractValidator<Ejecuta>
    {
        public EjecutaValidador()
        {
            RuleFor(x=>x.Id).NotEmpty();
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
            var uvt = await context.cntUvts.FindAsync(request.Id);
            if (uvt == null) {  
                    throw new Exception("Registro no encontrado");
            };   
            uvt.uvt_ano =  request.uvt_ano;
            uvt.uvt_valor = request.uvt_valor; 

            var resultado=  await context.SaveChangesAsync();
            if (resultado>0)
            {
                return Unit.Value;
            }
            throw new Exception("Error al modificar registro");



        }
    }

    
}