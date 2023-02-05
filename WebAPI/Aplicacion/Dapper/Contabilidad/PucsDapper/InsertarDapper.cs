namespace ContabilidadWebAPI.Aplicacion.Dapper.Contabilidad.PucsDapper;

public class InsertarPucsDapperRequest : IRequest
{

    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public int? IdPuctipo { get; set; }
    public int? IdTipocuenta { get; set; }
    public bool PacActiva { get; set; }
    public bool PacBase { get; set; }
    public bool PacAjusteniif { get; set; }

    public string IdUsuario { get; set; }
}

public class InsertarPucsDapperValidator : AbstractValidator<InsertarPucsDapperRequest>
{
    public InsertarPucsDapperValidator()
    {

        RuleFor(x => x.Codigo).NotEmpty();
        RuleFor(x => x.Nombre).NotEmpty();
        RuleFor(x => x.IdTipocuenta).NotEmpty();
        // RuleFor(x=>x.PacActiva).NotEmpty();
        // RuleFor(x=>x.PacBase).NotEmpty();
        // RuleFor(x=>x.PacAjusteniif).NotEmpty();
        RuleFor(x => x.IdUsuario).NotEmpty();


    }
}


public class InsertarPucsDapperHandler : IRequestHandler<InsertarPucsDapperRequest>
{

    private readonly IPucRepositorio _pucRepositorio;

    public InsertarPucsDapperHandler(IPucRepositorio pucRepositorio)
    {
        _pucRepositorio = pucRepositorio;
    }

    public async Task<Unit> Handle(InsertarPucsDapperRequest request, CancellationToken cancellationToken)
    {

        PucRepositorioModel modelo = new PucRepositorioModel
        {
            Codigo = request.Codigo,
            Nombre = request.Nombre,
            IdPuctipo = request.IdPuctipo,
            IdTipocuenta = request.IdTipocuenta,
            PacActiva = request.PacActiva,
            PacBase = request.PacBase,
            PacAjusteniif = request.PacAjusteniif,
            IdUsuario = request.IdUsuario
        };

        var resultado = await _pucRepositorio.Insertar(modelo);
        if (resultado > 0)
        {
            return Unit.Value;
        }

        throw new Exception("Error al registrar Cuenta");
    }
}

