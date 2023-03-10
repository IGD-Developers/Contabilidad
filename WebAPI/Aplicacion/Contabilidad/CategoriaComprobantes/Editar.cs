namespace ContabilidadWebAPI.Aplicacion.Contabilidad.CategoriaComprobantes;

public class EditarCategoriaComprobanteRequest : EditarCategoriaComprobantesModel, IRequest
{ }

public class EditarCategoriaComprobanteValidator : AbstractValidator<EditarCategoriaComprobanteRequest>
{
    public EditarCategoriaComprobanteValidator()
    {
        RuleFor(x => x.Codigo).NotEmpty();
        RuleFor(x => x.Nombre).NotEmpty();

    }
}

public class EditarCategoriaComprobanteHandler : IRequestHandler<EditarCategoriaComprobanteRequest>
{
    private readonly CntContext _context;
    private readonly IMapper _mapper;

    public EditarCategoriaComprobanteHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(EditarCategoriaComprobanteRequest request, CancellationToken cancellationToken)
    {

        {

            try
            {
                var entidad = await _context.cntCategoriaComprobantes.FindAsync(request.Id);

                if (entidad == null)
                {
                    throw new Exception("Categoría no encontrada");
                };

                var entidadDto = _mapper.Map<EditarCategoriaComprobantesModel, CntCategoriaComprobante>(request, entidad);

                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se realizaron cambios en la base de datos");
            }
            catch (Exception ex)
            {
                //TODO: MARIA  Llave duplicada  CODIGO BANCO Implementar

                throw new Exception("Error al editar registro catch " + ex.Message);

            }
        }
    }
}