namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Pucs;

public class EliminarPucRequest : IdPucModel, IRequest
{ }

public class EliminarPucValidator : AbstractValidator<EliminarPucRequest>
{
    public EliminarPucValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}

public class EliminarPucHandler : IRequestHandler<EliminarPucRequest>
{

    private readonly CntContext context;

    public EliminarPucHandler(CntContext context)
    {
        this.context = context;
    }

    public async Task<Unit> Handle(EliminarPucRequest request, CancellationToken cancellationToken)
    {
        var puc = await context.cntPucs.FindAsync(request.Id);
        if (puc == null)
        {
            throw new Exception("Registro no encontrado");
        };

        context.cntPucs.Remove(puc);

        try
        {
            var respuesta = await context.SaveChangesAsync();
            if (respuesta > 0)
            {
                return Unit.Value;
            }

            throw new Exception("Error Eliminar registro ");
            throw new NotImplementedException();
        }
        catch (Exception ex)
        {
            throw new Exception("Error al eliminar registro catch " + ex.Message);
        }
    }

}