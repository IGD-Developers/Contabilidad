using System;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;
using ContabilidadWebAPI.Persistencia;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Uvts;

public class EditarUvtRequest : IRequest
{

    public int Id { get; set; }
    public int uvt_ano { get; set; }
    public double uvt_valor { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

}

public class EditarUvtValidator : AbstractValidator<EditarUvtRequest>
{
    public EditarUvtValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.uvt_ano).NotEmpty();
        RuleFor(x => x.uvt_valor).NotEmpty();

    }
}


public class EditarUvtHandler : IRequestHandler<EditarUvtRequest>
{

    private readonly CntContext context;

    public EditarUvtHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<Unit> Handle(EditarUvtRequest request, CancellationToken cancellationToken)
    {
        var uvt = await context.cntUvts.FindAsync(request.Id);
        if (uvt == null)
        {
            throw new Exception("Registro no encontrado");
        };
        uvt.UvtAno = request.uvt_ano;
        uvt.UvtValor = request.uvt_valor;

        var resultado = await context.SaveChangesAsync();
        if (resultado > 0)
        {
            return Unit.Value;
        }
        throw new Exception("Error al modificar registro");



    }
}