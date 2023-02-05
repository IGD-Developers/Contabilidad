namespace ContabilidadWebAPI.Aplicacion.Contabilidad.ResponsabilidadTerceros;

public class ConsultarResponsabilidadTerceroRequest : IRequest<ResponsabilidadTerceroModel>
{
    public int Id;
}

public class ConsultarResponsabilidadTerceroHandler : IRequestHandler<ConsultarResponsabilidadTerceroRequest, ResponsabilidadTerceroModel>
{
    private readonly CntContext _context;
    private readonly IMapper _mapper;

    public ConsultarResponsabilidadTerceroHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ResponsabilidadTerceroModel> Handle(ConsultarResponsabilidadTerceroRequest request, CancellationToken cancellationToken)
    {
        var consulta = await _context.cntResponsabilidadTerceros.FindAsync(request.Id);

        if (consulta == null)
        {
            throw new Exception("Responsabilidad Tercero consultada no se encontro");
        }

        var consultaModel = _mapper.Map<CntResponsabilidadTer, ResponsabilidadTerceroModel>(consulta);

        return consultaModel;
    }
}