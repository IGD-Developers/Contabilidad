using System;
using System.Threading;
using System.Threading.Tasks;
using ContabilidadWebAPI.Persistencia;
using FluentValidation;
using MediatR;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.NotaAclaratoriaCuentas;

public class EditarNotaAclaratoriaCuentaRequest : IRequest
{
    public int Id { get; set; }
    public int? id_notaaclaratoria { get; set; }
    public int? IdPuc { get; set; }
}

public class EditarNotaAclaratoriaCuentaValidator : AbstractValidator<EditarNotaAclaratoriaCuentaRequest>
{
    public EditarNotaAclaratoriaCuentaValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.id_notaaclaratoria).NotEmpty();
        RuleFor(x => x.IdPuc).NotEmpty();

    }
}

public class EditarNotaAclaratoriaCuentaHandler : IRequestHandler<EditarNotaAclaratoriaCuentaRequest>
{
    private readonly CntContext _context;

    public EditarNotaAclaratoriaCuentaHandler(CntContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(EditarNotaAclaratoriaCuentaRequest request, CancellationToken cancellationToken)
    {
        var nota = await _context.cntNotaAclaratoriaCuentas.FindAsync(request.Id);

        if (nota == null)
        {
            throw new Exception("No se encontro nota");
        }

        nota.IdNotaaclaratoria = request.id_notaaclaratoria ?? nota.IdNotaaclaratoria;
        nota.IdPuc = request.IdPuc ?? nota.IdPuc;

        var resultado = await _context.SaveChangesAsync();

        if (resultado > 0)
        {
            return Unit.Value;
        }

        throw new Exception("No se pudo editar la nota");

    }
}