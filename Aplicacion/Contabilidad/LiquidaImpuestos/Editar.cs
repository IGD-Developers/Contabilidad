using Persistencia;
using System;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;

namespace Aplicacion.Contabilidad.LiquidaImpuestos;

public class Editar
{

public class Ejecuta:IRequest
    {
        public int Id { get; set; }
        public int id_tipoimpuesto { get; set; }
        public int id_comprobante { get; set; }
        public int id_puc { get; set; }
        public int id_tercero { get; set; }
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
            RuleFor(x=>x.id_tercero).NotEmpty();
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
            liquidaImpuesto.id_tipoimpuesto = request.id_tipoimpuesto;
            liquidaImpuesto.id_comprobante = request.id_comprobante;
            liquidaImpuesto.id_puc = request.id_puc;
            liquidaImpuesto.id_tercero = request.id_tercero;
            //liquidaImpuesto.lim_fecha = request.lim_fecha;
            liquidaImpuesto.lim_fechainicial = request.lim_fechainicial;
            liquidaImpuesto.lim_fechafinal = request.lim_fechafinal;
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