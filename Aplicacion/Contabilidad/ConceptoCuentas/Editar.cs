using Persistencia;
using System;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;

namespace Aplicacion.Contabilidad.ConceptoCuentas;

public class Editar
{

public class Ejecuta: IRequest 
{
    public int Id { get; set; }
    public int id_exogenaconcepto { get; set; }
    public int id_puc { get; set; }
    public int id_formatocolumna { get; set; }
    public int id_tipooperacion { get; set; }
    public string estado { get; set; }
}

public class EjecutaValidador : AbstractValidator<Ejecuta>
    {
        public EjecutaValidador()
        {
            RuleFor(x=>x.Id).NotEmpty();
            RuleFor(x=>x.id_exogenaconcepto).NotEmpty();
            RuleFor(x=>x.id_puc).NotEmpty();
            RuleFor(x=>x.id_formatocolumna).NotEmpty();
            RuleFor(x=>x.id_tipooperacion).NotEmpty();
            RuleFor(x=>x.estado).NotEmpty();
    
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
        var conceptoCuenta = await context.cntConceptoCuentas.FindAsync(request.Id);

        if (conceptoCuenta == null) {
                throw new Exception("Concepto no encontrado");
            };

                conceptoCuenta.id_exogenaconcepto =request.id_exogenaconcepto;
                conceptoCuenta.id_puc =request.id_puc;
                conceptoCuenta.id_formatocolumna=request.id_formatocolumna;
                conceptoCuenta.id_tipooperacion =request.id_tipooperacion;
                conceptoCuenta.estado=request.estado;

        var resultado=  await context.SaveChangesAsync();
            if (resultado>0)
            {
                return Unit.Value;
            }

            throw new Exception("Error al modificar registro");    
         
    }


}

}