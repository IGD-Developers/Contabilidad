namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Meses;

public class EditarMesRequest : IRequest
{
    public int Id { get; set; }
    public int? mes_ano { get; set; }
    public int? mes_mes { get; set; }
    public bool? mes_cerrado { get; set; }
    public string IdUsuario { get; set; }

}

public class EditarMesValidator : AbstractValidator<EditarMesRequest>
{
    public EditarMesValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.mes_ano).NotEmpty();
        RuleFor(x => x.mes_mes).NotEmpty();
        RuleFor(x => x.mes_cerrado).NotEmpty();
        RuleFor(x => x.IdUsuario).NotEmpty();

    }
}

public class EditarMesHandler : IRequestHandler<EditarMesRequest>
{
    private readonly CntContext _context;

    public EditarMesHandler(CntContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(EditarMesRequest request, CancellationToken cancellationToken)
    {
        var cierre = await _context.cntMeses.FindAsync(request.Id);

        if (cierre == null)
        {
            throw new Exception("No se encontró cierre");
        }

        cierre.MesMes = request.mes_mes ?? cierre.MesMes;
        cierre.MesAno = request.mes_ano ?? cierre.MesAno;
        cierre.MesCerrado = request.mes_cerrado ?? cierre.MesCerrado;
        // if (request.IdUsuario!=null){
        //     cierre.IdUsuario = request.IdUsuario;
        // };
        //cierre.IdUsuario = request.IdUsuario ?? cierre.IdUsuario;
        cierre.IdUsuario = request.IdUsuario;

        // _context.Add(cierre);
        var resultado = await _context.SaveChangesAsync();

        if (resultado > 0)
        {
            return Unit.Value;
        }

        throw new Exception("No se pudo editar el cierre");


    }
}