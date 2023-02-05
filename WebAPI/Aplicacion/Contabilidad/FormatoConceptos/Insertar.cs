using ContabilidadWebAPI.Dominio.Contabilidad;
using System;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;
using ContabilidadWebAPI.Persistencia;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.FormatoConceptos;

public class InsertarFormatoConceptoRequest : IRequest
{

    public int IdExogenaformato { get; set; }
    public int IdExogenaconcepto { get; set; }

}

public class InsertarFormatoConceptoValidator : AbstractValidator<InsertarFormatoConceptoRequest>
{
    public InsertarFormatoConceptoValidator()
    {
        RuleFor(x => x.IdExogenaformato).NotEmpty();
        RuleFor(x => x.IdExogenaconcepto).NotEmpty();

    }

}

public class InsertarFormatoConceptoHandler : IRequestHandler<InsertarFormatoConceptoRequest>
{

    private readonly CntContext context;

    public InsertarFormatoConceptoHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<Unit> Handle(InsertarFormatoConceptoRequest request, CancellationToken cancellationToken)
    {

        var formatoConcepto = new CntFormatoConcepto
        {
            IdExogenaformato = request.IdExogenaformato,
            IdExogenaconcepto = request.IdExogenaconcepto
        };

        context.cntFormatoConceptos.Add(formatoConcepto);
        var respuesta = await context.SaveChangesAsync();
        if (respuesta > 0)
        {
            return Unit.Value;
        }
        throw new Exception("Error al insertar FormatoConcepto");
    }
}