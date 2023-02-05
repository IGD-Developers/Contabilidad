using System;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;
using ContabilidadWebAPI.Persistencia;


namespace ContabilidadWebAPI.Aplicacion.Contabilidad.ExogenaFormatos;

public class EditarExogenaFormatoRequest : IRequest
{
    public int Id { get; set; }
    public string Codigo { get; set; }
    public string Nombre { get; set; }
}

public class EditarExogenaFormatoValidator : AbstractValidator<EditarExogenaFormatoRequest>
{
    public EditarExogenaFormatoValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Codigo).NotEmpty();
        RuleFor(x => x.Nombre).NotEmpty();

    }
}

public class EditarExogenaFormatoHandler : IRequestHandler<EditarExogenaFormatoRequest>
{
    private readonly CntContext context;

    public EditarExogenaFormatoHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<Unit> Handle(EditarExogenaFormatoRequest request, CancellationToken cancellationToken)
    {
        var exogenaFormato = await context.cntExogenaFormatos.FindAsync(request.Id);
        if (exogenaFormato == null)
        {
            throw new Exception("Registro no encontrado");
        };
        exogenaFormato.Codigo = request.Nombre;
        exogenaFormato.Nombre = request.Nombre;
        var resultado = await context.SaveChangesAsync();
        if (resultado > 0)
        {
            return Unit.Value;
        }

        throw new Exception("Error al modificar registro");

    }
}