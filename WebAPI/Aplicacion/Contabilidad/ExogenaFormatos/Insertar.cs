using MediatR;
using ContabilidadWebAPI.Dominio.Contabilidad;
using System.Threading.Tasks;
using System.Threading;
using System;
using FluentValidation;
using ContabilidadWebAPI.Persistencia;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.ExogenaFormatos;

public class InsertarExogenaFormatoRequest : IRequest
{
    public string Codigo { get; set; }
    public string Nombre { get; set; }
}

public class InsertarExogenaFormatoValidator : AbstractValidator<InsertarExogenaFormatoRequest>
{
    public InsertarExogenaFormatoValidator()
    {
        RuleFor(x => x.Codigo).NotEmpty();
        RuleFor(x => x.Nombre).NotEmpty();

    }
}


public class InsertarExogenaFormatoHandler : IRequestHandler<InsertarExogenaFormatoRequest>
{
    private readonly CntContext context;

    public InsertarExogenaFormatoHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<Unit> Handle(InsertarExogenaFormatoRequest request, CancellationToken cancellationToken)
    {

        var exogenaFormato = new CntExogenaFormato()
        {
            Codigo = request.Nombre,
            Nombre = request.Nombre
        };

        context.cntExogenaFormatos.Add(exogenaFormato);
        var respuesta = await context.SaveChangesAsync();
        if (respuesta > 0)
        {
            return Unit.Value;
        }
        throw new Exception("Error al insertar ExogenaFormato");
    }
}