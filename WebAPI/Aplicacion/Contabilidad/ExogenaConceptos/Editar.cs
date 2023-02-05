using System;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;
using ContabilidadWebAPI.Persistencia;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.ExogenaConceptos;

public class EditarExogenaConceptoRequest : IRequest
{
    public int Id { get; set; }
    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public string Estado { get; set; }
}


public class EditarExogenaConceptoValidator : AbstractValidator<EditarExogenaConceptoRequest>
{
    public EditarExogenaConceptoValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Codigo).NotEmpty();
        RuleFor(x => x.Nombre).NotEmpty();
        RuleFor(x => x.Estado).NotEmpty();


    }
}

public class EditarExogenaConceptoHandler : IRequestHandler<EditarExogenaConceptoRequest>
{
    private readonly CntContext context;

    public EditarExogenaConceptoHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<Unit> Handle(EditarExogenaConceptoRequest request, CancellationToken cancellationToken)
    {

        var exogenaConcepto = await context.cntExogenaConceptos.FindAsync(request.Id);
        if (exogenaConcepto == null)
        {
            throw new Exception("Registro no encontrado");
        };
        exogenaConcepto.Codigo = request.Codigo;
        exogenaConcepto.Nombre = request.Nombre;
        exogenaConcepto.Estado = request.Estado;

        var resultado = await context.SaveChangesAsync();
        if (resultado > 0)
        {
            return Unit.Value;
        }

        throw new Exception("Error al modificar registro");
    }
}