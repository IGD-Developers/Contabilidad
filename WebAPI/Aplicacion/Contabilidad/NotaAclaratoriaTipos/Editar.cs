using System;
using System.Threading;
using System.Threading.Tasks;
using ContabilidadWebAPI.Persistencia;
using FluentValidation;
using MediatR;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.NotaAclaratoriaTipos;

public class EditarNotaAclaratoriaTipoRequest : IRequest
{
    public int Id { get; set; }
    public string Codigo { get; set; }
    public string Nombre { get; set; }
}

public class EditarNotaAclaratoriaTipoValidator : AbstractValidator<EditarNotaAclaratoriaTipoRequest>
{
    public EditarNotaAclaratoriaTipoValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Codigo).NotEmpty();
        RuleFor(x => x.Nombre).NotEmpty();

    }
}

public class EditarNotaAclaratoriaTipoHandler : IRequestHandler<EditarNotaAclaratoriaTipoRequest>
{
    private readonly CntContext _context;

    public EditarNotaAclaratoriaTipoHandler(CntContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(EditarNotaAclaratoriaTipoRequest request, CancellationToken cancellationToken)
    {
        var nota = await _context.cntNotaAclaratoriaTipos.FindAsync(request.Id);

        if (nota == null)
        {
            throw new Exception("No se encontro nota aclaratoria tipo");
        }

        nota.Nombre = request.Nombre ?? nota.Nombre;
        nota.Codigo = request.Codigo ?? nota.Codigo;

        var resultado = await _context.SaveChangesAsync();

        if (resultado > 0)
        {
            return Unit.Value;
        }

        throw new Exception("No se ppudo editar la nota aclaratoria tipo");


    }
}