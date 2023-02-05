using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Regimen;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using MediatR;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Regimenes;

public class ConsultarRegimenRequest : IRequest<RegimenModel>
{
    public int Id;
}

public class ConsultarRegimenHandler : IRequestHandler<ConsultarRegimenRequest, RegimenModel>
{
    private readonly CntContext _context;
    private readonly IMapper _mapper;

    public ConsultarRegimenHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<RegimenModel> Handle(ConsultarRegimenRequest request, CancellationToken cancellationToken)
    {
        var consultaId = await _context.CntRegimenes.FindAsync(request.Id);

        if (consultaId == null)
        {
            throw new Exception("Regimen Consultado no Existe");
        }

        var consultaIdModel = _mapper.Map<CntRegimen, RegimenModel>(consultaId);
        return consultaIdModel;
    }
}