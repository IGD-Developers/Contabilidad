
using Persistencia;
using System;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;

namespace Aplicacion.Contabilidad.Consecutivos;

public class Editar
{
      public class Ejecuta : IRequest
    {

        public int Id { get; set; }
        public int id_tipocomprobante { get; set; }
        public int id_sucursal { get; set; }
        public string co_ano { get; set; }
        public string co_mes { get; set; }
        public int co_consecutivo { get; set; }
    }

    public class EjecutaValidador : AbstractValidator<Ejecuta>
    {
        public EjecutaValidador()
        {
            RuleFor(x=>x.Id).NotEmpty();
            RuleFor(x=>x.id_tipocomprobante).NotEmpty();
            RuleFor(x=>x.co_ano).NotEmpty();
            RuleFor(x=>x.co_mes).NotEmpty();
            RuleFor(x=>x.co_consecutivo).NotEmpty();
    
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

            var consecutivo = await context.cntConsecutivos.FindAsync(request.Id);

            if (consecutivo == null) {
                throw new Exception("Registro no encontrado");
            };
            //Ojo la sucursal no es modificable
            consecutivo.id_tipocomprobante = request.id_tipocomprobante;
            //consecutivo.id_sucursal = request.id_sucursal;
            consecutivo.co_ano = request.co_ano;
            consecutivo.co_mes = request.co_mes;
            consecutivo.co_consecutivo = request.co_consecutivo;
            var resultado=  await context.SaveChangesAsync();
            if (resultado>0)
            {
                return Unit.Value;
            }

            throw new Exception("Error al modificar registro");


        }
    }


}