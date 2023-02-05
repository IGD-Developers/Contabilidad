using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.TipoImpuestos;
using ContabilidadWebAPI.Persistencia;
using ContabilidadWebAPI.Dominio.Contabilidad;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.TipoImpuestos;

public class ConsultarTipoImpuestoRequest : TipoImpuestosIdModel, IRequest<ListarTipoImpuestosModel>
{ }

public class ConsultarTipoImpuestoHandler : IRequestHandler<ConsultarTipoImpuestoRequest, ListarTipoImpuestosModel>
{
    private CntContext _context;

    private readonly IMapper _mapper;



    public ConsultarTipoImpuestoHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ListarTipoImpuestosModel> Handle(ConsultarTipoImpuestoRequest request, CancellationToken cancellationToken)
    {


        var entidad = await _context.cntTipoImpuestos
        .SingleOrDefaultAsync(i => i.Id == request.Id);

        if (entidad == null)
        {
            throw new Exception("Registro no encontrado");
        };
        var entidadDto = _mapper.Map<CntTipoImpuesto, ListarTipoImpuestosModel>(entidad);
        return entidadDto;




    }

}