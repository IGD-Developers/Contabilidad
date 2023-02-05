namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Terceros;

public class EliminarTerceroRequest : EliminarTerceroModel, IRequest { }

public class EliminarTerceroHandler : IRequestHandler<EliminarTerceroRequest>
{
    private readonly CntContext _context;

    public EliminarTerceroHandler(CntContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(EliminarTerceroRequest request, CancellationToken cancellationToken)
    {
        var Tercero = await _context.CntTerceros.FindAsync(request.Id);
        if (Tercero == null)
        {
            throw new Exception("Tercero no existe");
        }

        var responsabilidades = _context.cntResponsabilidadTerceros
            .Where(z => z.IdTercero == request.Id)
            .ToList();


        var transaction = _context.Database.BeginTransaction();
        try
        {
            if (responsabilidades != null)
            {
                _context.RemoveRange(responsabilidades);
            }

            _context.Remove(Tercero);

            var resultado = await _context.SaveChangesAsync();

            if (resultado > 0)
            {
                transaction.Commit();
                return Unit.Value;
            }

            throw new Exception("Error al Eliminar Tercero");

        }
        catch (Exception ex)
        {

            throw new Exception("Error al Eliminar Tercero catch " + ex.Message);

        }
    }
}