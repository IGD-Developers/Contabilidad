using System;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;
using ContabilidadWebAPI.Persistencia;


namespace ContabilidadWebAPI.Aplicacion.Contabilidad.FormatoConceptos;

public class EditarFormatoConceptoRequest : IRequest
{
    public int Id { get; set; }
    public int IdExogenaformato { get; set; }
    public int IdExogenaconcepto { get; set; }

}

public class EditarFormatoConceptoValidator : AbstractValidator<EditarFormatoConceptoRequest>
{
    public EditarFormatoConceptoValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.IdExogenaformato).NotEmpty();
        RuleFor(x => x.IdExogenaconcepto).NotEmpty();

    }

}

public class EditarFormatoConceptoHandler : IRequestHandler<EditarFormatoConceptoRequest>
{
    private readonly CntContext context;

    public EditarFormatoConceptoHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<Unit> Handle(EditarFormatoConceptoRequest request, CancellationToken cancellationToken)
    {

        var formatoConcepto = await context.cntFormatoConceptos.FindAsync(request.Id);
        if (formatoConcepto == null)
        {
            throw new Exception("Registro no encontrado");
        };

        formatoConcepto.IdExogenaformato = request.IdExogenaformato;
        formatoConcepto.IdExogenaconcepto = request.IdExogenaconcepto;

        var resultado = await context.SaveChangesAsync();
        if (resultado > 0)
        {
            return Unit.Value;
        }

        throw new Exception("Error al modificar registro");

    }
}