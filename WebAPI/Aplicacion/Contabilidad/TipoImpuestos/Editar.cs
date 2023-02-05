using System;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;
using AutoMapper;
using ContabilidadWebAPI.Persistencia;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.TipoImpuestos;
using ContabilidadWebAPI.Dominio.Contabilidad;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.TipoImpuestos;

public class EditarTipoImpuestoRequest : EditarTipoImpuestosModel, IRequest
{ }

public class EditarTipoImpuestoValidator : AbstractValidator<EditarTipoImpuestoRequest>
{
    public EditarTipoImpuestoValidator()
    {
        RuleFor(x => x.Codigo).NotEmpty();
        RuleFor(x => x.Nombre).NotEmpty();

    }
}

public class EditarTipoImpuestoHandler : IRequestHandler<EditarTipoImpuestoRequest>
{

    private readonly CntContext _context;
    private readonly IMapper _mapper;



    public EditarTipoImpuestoHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(EditarTipoImpuestoRequest request, CancellationToken cancellationToken)
    {
        var entidad = await _context.cntTipoImpuestos.FindAsync(request.Id);

        try
        {
            if (entidad == null)
            {
                throw new Exception("Registro no encontrado");
            };

            var entidadDto = _mapper.Map<EditarTipoImpuestosModel, CntTipoImpuesto>(request, entidad);
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