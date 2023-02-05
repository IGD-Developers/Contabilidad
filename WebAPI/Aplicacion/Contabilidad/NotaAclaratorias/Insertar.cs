namespace ContabilidadWebAPI.Aplicacion.Contabilidad.NotaAclaratorias;

public class InsertarNotaAclaratoriaRequest : InsertarNotaAclaratoriaModel, IRequest
{ }

public class InsertarNotaAclaratoriaValidator : AbstractValidator<InsertarNotaAclaratoriaRequest>
{
    public InsertarNotaAclaratoriaValidator()
    {
        RuleFor(x => x.NacFecha).NotEmpty();
        RuleFor(x => x.IdNotaaclaratoriatipo).NotEmpty();
        RuleFor(x => x.NacTitulo).NotEmpty();
        RuleFor(x => x.NacDetalle).NotEmpty();
        RuleFor(x => x.IdUsuario).NotEmpty();
    }
}

public class InsertarNotaAclaratoriaHandler : IRequestHandler<InsertarNotaAclaratoriaRequest>
{
    private readonly CntContext _context;
    private readonly IMapper _mapper;

    public InsertarNotaAclaratoriaHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(InsertarNotaAclaratoriaRequest request, CancellationToken cancellationToken)
    {
        //TODO: NO USAR LAS ENTIDADES DE DOMINIO EN LO POSIBLE
        try
        {
            var notaTipo = await _context.cntNotaAclaratoriaTipos
                .Where(t => t.Id == request.IdNotaaclaratoriatipo)
                .Select(x => new CntNotaAclaratoriaTipo() { Codigo = x.Codigo, Nombre = x.Nombre })
                .SingleOrDefaultAsync();

            if (notaTipo == null)
            {
                throw new Exception("Tipo de nota Aclaratoria no existe");
            }

            if (notaTipo.Codigo == "CUE")
            {

                var codCuenta = await _context.cntPucs.FindAsync(request.IdPuc);
                if (codCuenta == null)
                {
                    throw new Exception("Codigo de Cuenta no existe en el puc");
                }

            }
            else
            {
                request.IdPuc = null;
            }



            var notaAclaratoria = _mapper.Map<InsertarNotaAclaratoriaModel, CntNotaAclaratoria>(request);

            _context.cntNotaAclaratorias.Add(notaAclaratoria);

            var valor = await _context.SaveChangesAsync();

            if (valor > 0)
            {
                return Unit.Value;
            }

            throw new Exception("No se pudo insertar la nota aclararotia");
        }
        catch (SystemException e)
        {
            //TODO: AGGD Mensaje de Error no debe enviarse al cliente
            throw new Exception("Error al Insertar nota aclaratoria catch..", e);
        }
    }
}