using MediatR;
using System;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;
using AutoMapper;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.CentroCostos;
using ContabilidadWebAPI.Persistencia;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.CentroCostos;

public class EditarCentroCostoRequest : EditarCentroCostosModel, IRequest
{ }


public class EditarCentroCostoValidator : AbstractValidator<EditarCentroCostoRequest>
{
    public EditarCentroCostoValidator()
    {
        RuleFor(x => x.Codigo).NotEmpty();
        RuleFor(x => x.Nombre).NotEmpty();

    }
}

public class EditarCentroCostoHandler : IRequestHandler<EditarCentroCostoRequest>
{
    private CntContext _context;
    private readonly IMapper _mapper;



    public EditarCentroCostoHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(EditarCentroCostoRequest request, CancellationToken cancellationToken)
    {

        try
        {
            var entidad = await _context.cntCentroCostos.FindAsync(request.Id);

            if (entidad == null)
            {
                throw new Exception("Centro de Costo no encontrado");
            };

            var entidadDto = _mapper.Map<EditarCentroCostosModel, CntCentroCosto>(request, entidad);
            var resultado = await _context.SaveChangesAsync();
            if (resultado > 0)
            {
                return Unit.Value;
            }

            throw new Exception("No se realizaron modificaciones en la base de datos");
        }
        catch (Exception ex)
        {
            //TODO: MARIA  Llave duplicada  CODIGO Centro Costo Implementar

            throw new Exception("Error al editar registro catch " + ex.Message);
        }

    }
}