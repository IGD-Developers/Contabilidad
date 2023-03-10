namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Meses;

public class InsertarMesRequest : IRequest
{
    public int mes_ano { get; set; }
    public int mes_mes { get; set; }
    public bool mes_cerrado { get; set; }
    public string IdUsuario { get; set; }

}

public class InsertarMesValidator : AbstractValidator<InsertarMesRequest>
{
    public InsertarMesValidator()
    {
        RuleFor(x => x.mes_ano).NotEmpty();
        RuleFor(x => x.mes_mes).NotEmpty();
        RuleFor(x => x.mes_cerrado).NotEmpty();
        RuleFor(x => x.IdUsuario).NotEmpty();

    }
}

public class InsertarMesHandler : IRequestHandler<InsertarMesRequest>
{
    public readonly CntContext _context;

    public InsertarMesHandler(CntContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(InsertarMesRequest request, CancellationToken cancellationToken)
    {
        var mes = new CntMes
        {
            MesAno = request.mes_ano,
            MesMes = request.mes_mes,
            MesCerrado = request.mes_cerrado,
            IdUsuario = request.IdUsuario

        };

        _context.cntMeses.Add(mes);
        var valor = await _context.SaveChangesAsync();

        if (valor > 0)
        {
            return Unit.Value;
        }

        throw new Exception("No se pudo insertar el Mes");
    }
}