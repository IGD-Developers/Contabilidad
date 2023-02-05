using System;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;
using AutoMapper;
using ContabilidadWebAPI.Persistencia;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Bancos;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Bancos;

public class EditarBancoRequest : EditarBancosModel, IRequest
{ }


public class EditarBancoValidator : AbstractValidator<EditarBancoRequest>
{
    public EditarBancoValidator()
    {
        //RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Codigo).NotEmpty();
        RuleFor(x => x.Nombre).NotEmpty();

    }
}

public class EditarBancoHandler : IRequestHandler<EditarBancoRequest>
{
    private readonly CntContext _context;
    private readonly IMapper _mapper;



    public EditarBancoHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;



    }

    public async Task<Unit> Handle(EditarBancoRequest request, CancellationToken cancellationToken)
    {


        try
        {
            var banco = await _context.cntBancos.FindAsync(request.Id);
            if (banco == null)
            {
                throw new Exception("Banco no encontrado");
            };

            //Como vamos a grabar primero el modelo y luego la entidad:
            var entidadDto = _mapper.Map<EditarBancosModel, CntBanco>(request, banco);

            //El mapeo va asi en el mappingprofile: CreateMap<EditarEntidadModel,Entidad>();

            var resultado = await _context.SaveChangesAsync();
            if (resultado > 0)
            {
                return Unit.Value;
            }
            throw new Exception("No se realizaron modificaciones al registro");
        }
        catch (Exception ex)
        {
            //TODO: MARIA Llave duplicada  CODIGO BANCO Implementar

            throw new Exception("Error al editar registro catch " + ex.Message);
        }

    }
}