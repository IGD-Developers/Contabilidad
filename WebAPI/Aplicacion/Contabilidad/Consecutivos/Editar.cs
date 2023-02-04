using System;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;
using ContabilidadWebAPI.Persistencia;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Consecutivos;

public class Editar
{
    public class Ejecuta : IRequest
    {

        public int Id { get; set; }
        public int IdTipocomprobante { get; set; }
        public int IdSucursal { get; set; }
        public string CoAno { get; set; }
        public string CoMes { get; set; }
        public int CoConsecutivo { get; set; }
    }

    public class EjecutaValidador : AbstractValidator<Ejecuta>
    {
        public EjecutaValidador()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.IdTipocomprobante).NotEmpty();
            RuleFor(x => x.CoAno).NotEmpty();
            RuleFor(x => x.CoMes).NotEmpty();
            RuleFor(x => x.CoConsecutivo).NotEmpty();

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

            var consecutivo = await context.cntConsecutivos.FindAsync(request.Id);

            if (consecutivo == null)
            {
                throw new Exception("Registro no encontrado");
            };
            //Ojo la Sucursal no es modificable
            consecutivo.IdTipocomprobante = request.IdTipocomprobante;
            //consecutivo.IdSucursal = request.IdSucursal;
            consecutivo.CoAno = request.CoAno;
            consecutivo.CoMes = request.CoMes;
            consecutivo.CoConsecutivo = request.CoConsecutivo;
            var resultado = await context.SaveChangesAsync();
            if (resultado > 0)
            {
                return Unit.Value;
            }

            throw new Exception("Error al modificar registro");


        }
    }


}