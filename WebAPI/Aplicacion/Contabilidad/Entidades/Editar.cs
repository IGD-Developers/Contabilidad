namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Entidades;

public class EditarEntidadRequest : EditarEntidadModel, IRequest
{


}
public class EditarEntidadValidator : AbstractValidator<EditarEntidadRequest>
{
    public EditarEntidadValidator()
    {
        //RuleFor(x=>x.Id).NotEmpty();
        RuleFor(x => x.IdTercero).NotEmpty();
        RuleFor(x => x.IdTipoimpuesto).NotEmpty();

    }
}

public class EditarEntidadHandler : IRequestHandler<EditarEntidadRequest>
{
    private readonly CntContext _context;
    private readonly IMapper _mapper;



    public EditarEntidadHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(EditarEntidadRequest request, CancellationToken cancellationToken)
    {

        var entidad = await _context.cntEntidades.FindAsync(request.Id);
        if (entidad == null)
        {
            throw new Exception("Registro no encontrado");
        };

        var endidadDto = _mapper.Map<EditarEntidadModel, CntEntidad>(request, entidad);

        try
        {
            var resultado = await _context.SaveChangesAsync();
            if (resultado > 0)
            {
                return Unit.Value;
            }

            throw new Exception("No se realizaron modificaciones al registro");
        }
        catch (Exception ex)
        {
            throw new Exception("Error al editar registro catch " + ex.Message);
        }

    }
}