using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.CategoriaComprobantes;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using FluentValidation;
using MediatR;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.CategoriaComprobantes;

public class InsertarCategoriaComprobanteRequest : InsertarCategoriaComprobantesModel, IRequest
{ }


public class InsertarCategoriaComprobanteValidator : AbstractValidator<InsertarCategoriaComprobanteRequest>
{
    public InsertarCategoriaComprobanteValidator()
    {
        RuleFor(x => x.Codigo).NotEmpty();
        RuleFor(x => x.Nombre).NotEmpty();

    }
}
public class InsertarCategoriaComprobanteHandler : IRequestHandler<InsertarCategoriaComprobanteRequest>
{

    private CntContext _context;
    private readonly IMapper _mapper;



    public InsertarCategoriaComprobanteHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(InsertarCategoriaComprobanteRequest request, CancellationToken cancellationToken)
    {

        var entidadDto = _mapper.Map<InsertarCategoriaComprobantesModel, CntCategoriaComprobante>(request);

        //TODO: MARIA Llave duplicada Codigo 
        try
        {
            _context.cntCategoriaComprobantes.Add(entidadDto);
            var estado = await _context.SaveChangesAsync();
            if (estado > 0)
            {
                return Unit.Value;
            }
            throw new Exception("Error al insertar registro");
        }
        catch (Exception ex)
        {
            throw new Exception("Error al Insertar registro catch " + ex.Message);

        }
    }
}