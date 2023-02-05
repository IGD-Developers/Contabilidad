namespace ContabilidadWebAPI.Aplicacion.Contabilidad.NotaAclaratoriaCuentas;

public class InsertarNotaAclaratoriaCuentaRequest : IRequest
{
    public int id_notaaclaratoria { get; set; }
    public int IdPuc { get; set; }
}

public class InsertarNotaAclaratoriaCuentaValidator : AbstractValidator<InsertarNotaAclaratoriaCuentaRequest>
{
    public InsertarNotaAclaratoriaCuentaValidator()
    {
        RuleFor(x => x.id_notaaclaratoria).NotEmpty();
        RuleFor(x => x.IdPuc).NotEmpty();

    }
}

public class InsertarNotaAclaratoriaCuentaHandler : IRequestHandler<InsertarNotaAclaratoriaCuentaRequest>
{
    private readonly CntContext _context;

    public InsertarNotaAclaratoriaCuentaHandler(CntContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(InsertarNotaAclaratoriaCuentaRequest request, CancellationToken cancellationToken)
    {
        var nota = new CntNotaAclaratoriaCuenta
        {

            IdNotaaclaratoria = request.id_notaaclaratoria,
            IdPuc = request.IdPuc
        };

        _context.cntNotaAclaratoriaCuentas.Add(nota);
        var valor = await _context.SaveChangesAsync();

        if (valor > 0)
        {
            return Unit.Value;
        }

        throw new System.Exception("No se pudo insertar la nota aclarotia Cuenta");
    }
}