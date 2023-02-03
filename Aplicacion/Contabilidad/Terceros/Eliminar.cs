using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.Models.Contabilidad.Tercero;
using MediatR;
using Persistencia;

namespace Aplicacion.Contabilidad.Terceros;

public class Eliminar
{
    public class Ejecuta : EliminarTerceroModel, IRequest{}

    public class Manejador : IRequestHandler<Ejecuta>{
        private readonly CntContext _context;

        public Manejador(CntContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
        {
            var tercero = await _context.CntTerceros.FindAsync(request.Id);
            if(tercero==null){
                throw new Exception("Tercero no existe");
            }

            var responsabilidades = _context.cntResponsabilidadTerceros
                .Where(z => z.id_tercero == request.Id)
                .ToList();


            var transaction = _context.Database.BeginTransaction();
            try {
                if(responsabilidades != null){
                    _context.RemoveRange(responsabilidades);
                }

                _context.Remove(tercero);                   

                var resultado = await _context.SaveChangesAsync();

                if(resultado > 0){
                    transaction.Commit();
                    return Unit.Value;
                }

                throw new Exception("Error al Eliminar tercero");

            } catch (Exception ex) {

                throw new Exception("Error al Eliminar tercero catch " + ex.Message);
                 
            }
        }
    }
    
}