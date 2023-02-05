using System.ComponentModel.DataAnnotations;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.NotaAclaratoriaTipos;

public class InsertarNotaAclaratoriaTipoRequest : IRequest
{

    [StringLength(3, MinimumLength = 3, ErrorMessage = "Debe ingresar solo 3 caracteres")]
    public string Codigo { get; set; }
    public string Nombre { get; set; }

}

public class InsertarNotaAclaratoriaTipoValidator : AbstractValidator<InsertarNotaAclaratoriaTipoRequest>
{
    public InsertarNotaAclaratoriaTipoValidator()
    {
        RuleFor(x => x.Codigo).NotEmpty();
        RuleFor(x => x.Nombre).NotEmpty();

    }
}

public class InsertarNotaAclaratoriaTipoHandler : IRequestHandler<InsertarNotaAclaratoriaTipoRequest>
{
    private readonly CntContext _context;

    public InsertarNotaAclaratoriaTipoHandler(CntContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(InsertarNotaAclaratoriaTipoRequest request, CancellationToken cancellationToken)
    {
        var nota = new CntNotaAclaratoriaTipo
        {
            Codigo = request.Codigo,
            Nombre = request.Nombre
        };

        _context.cntNotaAclaratoriaTipos.Add(nota);
        var valor = await _context.SaveChangesAsync();

        if (valor > 0)
        {
            return Unit.Value;
        }

        throw new Exception("No se pudo insertar la nota aclaratoria tipo");

    }
}