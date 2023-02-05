using System;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;
using ContabilidadWebAPI.Persistencia;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Consecutivos;

public class EditarConsecutivoRequest : IRequest
{

    public int Id { get; set; }
    public int IdTipocomprobante { get; set; }
    public int IdSucursal { get; set; }
    public string CoAno { get; set; }
    public string CoMes { get; set; }
    public int CoConsecutivo { get; set; }
}

public class EditarConsecutivoValidator : AbstractValidator<EditarConsecutivoRequest>
{
    public EditarConsecutivoValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.IdTipocomprobante).NotEmpty();
        RuleFor(x => x.CoAno).NotEmpty();
        RuleFor(x => x.CoMes).NotEmpty();
        RuleFor(x => x.CoConsecutivo).NotEmpty();

    }
}


public class EditarConsecutivoHandler : IRequestHandler<EditarConsecutivoRequest>
{
    private readonly CntContext context;

    public EditarConsecutivoHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<Unit> Handle(EditarConsecutivoRequest request, CancellationToken cancellationToken)
    {

        var consecutivo = await context.cntConsecutivos.FindAsync(request.Id);

        if (consecutivo == null)
        {
            throw new Exception("Registro no encontrado");
        };
        //Ojo la Sucursal no es modificable
        consecutivo.IdTipocomprobante = request.IdTipocomprobante;
        //consecutivo.IdSucursal = request.IdSucursal;
        consecutivo.CoAno = request.CoAno;
        consecutivo.CoMes = request.CoMes;
        consecutivo.CoConsecutivo = request.CoConsecutivo;
        var resultado = await context.SaveChangesAsync();
        if (resultado > 0)
        {
            return Unit.Value;
        }

        throw new Exception("Error al modificar registro");


    }
}