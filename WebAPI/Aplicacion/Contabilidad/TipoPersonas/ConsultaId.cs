using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.TipoPersona;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using MediatR;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.TipoPersonas;

public class ConsultarTipoPersonaRequest : IRequest<TipoPersonaModel>
{
    public int Id;
}

public class ConsultarTipoPersonaHandler : IRequestHandler<ConsultarTipoPersonaRequest, TipoPersonaModel>
{
    private readonly CntContext _context;
    private readonly IMapper _mapper;

    public ConsultarTipoPersonaHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TipoPersonaModel> Handle(ConsultarTipoPersonaRequest request, CancellationToken cancellationToken)
    {
        var consultaId = await _context.CntTipoPersonas.FindAsync(request.Id);

        if (consultaId == null)
        {
            throw new Exception("Tipo de persona no existe");
        }

        var consultaIdModel = _mapper.Map<CntTipoPersona, TipoPersonaModel>(consultaId);

        return consultaIdModel;
    }
}