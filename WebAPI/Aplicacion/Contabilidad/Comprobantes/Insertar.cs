namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Comprobantes;

public class InsertarComprobanteRequest : InsertarComprobantesModel, IRequest
{

}

public class InsertarComprobanteValidator : AbstractValidator<InsertarComprobanteRequest>
{
    public InsertarComprobanteValidator()
    {
        RuleFor(x => x.IdSucursal).NotEmpty();
        RuleFor(x => x.IdTipocomprobante).NotEmpty();
        RuleFor(x => x.IdTercero).NotEmpty();
        RuleFor(x => x.CcoFecha).NotEmpty();
        RuleFor(x => x.CcoDocumento).NotEmpty();
        RuleFor(x => x.CcoDetalle).NotEmpty();
        RuleFor(x => x.IdUsuario).NotEmpty();

    }
}



public class InsertarComprobanteHandler : IRequestHandler<InsertarComprobanteRequest>
{

    private readonly IMapper _mapper;
    private IInsertarComprobante _insertarComprobante;
    private readonly CntContext _context;

    public InsertarComprobanteHandler(CntContext context, IInsertarComprobante insertarComprobante, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
        _insertarComprobante = insertarComprobante;

    }


    public async Task<Unit> Handle(InsertarComprobanteRequest request, CancellationToken cancellationToken)
    {

        //TODO:  MARIA Validar "IdSucursal", "IdTipocomprobante",  "IdTercero","IdUsuario", "IdCentrocosto", "IdPuc" "IdTercero" 
        //TODO: MARIA Asignar "IdModulo" según  el modulo

        var transaction = _context.Database.BeginTransaction();

        try
        {
            var respuestacc = await _insertarComprobante.Insertar(request);

            transaction.Commit();
            return Unit.Value;



        }
        catch (Exception ex)
        {
            throw new Exception("Error al insertar Comprobante catch " + ex.Message);

        }
    }
}
