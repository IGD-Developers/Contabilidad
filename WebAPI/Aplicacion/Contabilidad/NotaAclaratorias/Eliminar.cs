namespace ContabilidadWebAPI.Aplicacion.Contabilidad.NotaAclaratorias;

public class EliminarNotaAclaratoriaRequest : EliminarNotaAclaratoriaModel, IRequest { }

public class EliminarNotaAclaratoriaHandler : IRequestHandler<EliminarNotaAclaratoriaRequest>
{
    private readonly CntContext _context;

    public EliminarNotaAclaratoriaHandler(CntContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(EliminarNotaAclaratoriaRequest request, CancellationToken cancellationToken)
    {
        //TODO: Traer solo un campo 
        var nota = await _context.cntNotaAclaratorias.FindAsync(request.Id);
        if (nota == null)
        {
            throw new Exception("Nota Aclaratoria a Eliminar no existe");
        }

        try
        {
            _context.Remove(nota);

            var resultado = await _context.SaveChangesAsync();
            if (resultado > 0)
            {
                return Unit.Value;
            }

            throw new Exception("No se elimino la nota aclaratoria");

        }
        catch (SystemException e)
        {
            throw new Exception("Ocurrio un error al eliminar la nota aclaratoria cath", e);
        }



    }
}