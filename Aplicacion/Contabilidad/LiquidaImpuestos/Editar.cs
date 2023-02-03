using Persistencia;
using System;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;

namespace Aplicacion.Contabilidad.LiquidaImpuestos
{
    public class Editar
    {

public class Ejecuta:IRequest
        {
            public int Id { get; set; }
            public int id_tipoimpuesto { get; set; }
            public int id_comprobante { get; set; }
            public int id_puc { get; set; }
            public int IdTercero { get; set; }
            public DateTime lim_fecha { get; set; }
            public DateTime lim_fechainicial { get; set; }
            public DateTime lim_fechafinal { get; set; }
            public string id_usuario { get; set; }
        }

         public class EjecutaValidador : AbstractValidator<Ejecuta>
        {
            public EjecutaValidador()
            {
                RuleFor(x=>x.Id).NotEmpty();
                RuleFor(x=>x.id_tipoimpuesto).NotEmpty();
                RuleFor(x=>x.id_comprobante).NotEmpty();
                RuleFor(x=>x.id_puc).NotEmpty();
                RuleFor(x=>x.IdTercero).NotEmpty();
                RuleFor(x=>x.lim_fechainicial).NotEmpty();
                RuleFor(x=>x.lim_fechafinal).NotEmpty();
                RuleFor(x=>x.id_usuario).NotEmpty();
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
                

                var liquidaImpuesto = await context.cntLiquidaImpuestos.FindAsync(request.Id);
                if (liquidaImpuesto == null) {  
                    throw new Exception("Registro no encontrado");
                };       
                liquidaImpuesto.IdTipoimpuesto = request.id_tipoimpuesto;
                liquidaImpuesto.IdComprobante = request.id_comprobante;
                liquidaImpuesto.IdPuc = request.id_puc;
                liquidaImpuesto.IdTercero = request.IdTercero;
                //liquidaImpuesto.lim_fecha = request.lim_fecha;
                liquidaImpuesto.LimFechainicial = request.lim_fechainicial;
                liquidaImpuesto.LimFechafinal = request.lim_fechafinal;
               // liquidaImpuesto.id_usuario = request.id_usuario;

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