using System;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;
using ContabilidadWebAPI.Persistencia;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.DetalleComprobantes;

public class EditarDetalleComprobanteRequest : IRequest
{


    public int Id { get; set; }
    public int IdComprobante { get; set; }
    public int IdCentrocosto { get; set; }
    public int IdPuc { get; set; }
    public int IdTercero { get; set; }
    public double DcoBase { get; set; }
    public double DcoTarifa { get; set; }
    public double DcoDebito { get; set; }
    public double DcoCredito { get; set; }
    public string DcoDetalle { get; set; }
}



public class EditarDetalleComprobanteValidator : AbstractValidator<EditarDetalleComprobanteRequest>
{
    public EditarDetalleComprobanteValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.IdComprobante).NotEmpty();
        RuleFor(x => x.IdCentrocosto).NotEmpty();
        RuleFor(x => x.IdPuc).NotEmpty();
        RuleFor(x => x.IdTercero).NotEmpty();
        RuleFor(x => x.DcoTarifa).NotEmpty();
        RuleFor(x => x.DcoDebito).NotEmpty();
        RuleFor(x => x.DcoCredito).NotEmpty();
        RuleFor(x => x.DcoDetalle).NotEmpty();
    }
}
public class EditarDetalleComprobanteHandler : IRequestHandler<EditarDetalleComprobanteRequest>
{
    private readonly CntContext context;

    public EditarDetalleComprobanteHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<Unit> Handle(EditarDetalleComprobanteRequest request, CancellationToken cancellationToken)
    {
        var detalleComprobante = await context.cntDetalleComprobantes.FindAsync(request.Id);

        if (detalleComprobante == null)
        {
            throw new Exception("Registro no encontrado");
        };

        detalleComprobante.IdComprobante = request.IdComprobante;
        detalleComprobante.IdCentrocosto = request.IdCentrocosto;
        detalleComprobante.IdPuc = request.IdPuc;
        detalleComprobante.IdTercero = request.IdTercero;
        detalleComprobante.DcoBase = request.DcoBase;
        detalleComprobante.DcoTarifa = request.DcoTarifa;
        detalleComprobante.DcoDebito = request.DcoTarifa;
        detalleComprobante.DcoCredito = request.DcoCredito;
        detalleComprobante.DcoDetalle = request.DcoDetalle;


        var resultado = await context.SaveChangesAsync();
        if (resultado > 0)
        {
            return Unit.Value;
        }

        throw new Exception("Error al modificar registro");
    }
}