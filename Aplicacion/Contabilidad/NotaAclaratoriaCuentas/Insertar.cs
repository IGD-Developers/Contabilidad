using System.Threading;
using System.Threading.Tasks;
using Dominio.Contabilidad;
using FluentValidation;
using MediatR;
using Persistencia;

namespace Aplicacion.Contabilidad.NotaAclaratoriaCuentas;

public class Insertar
{
    public class Ejecuta : IRequest{
        public int id_notaaclaratoria { get; set; }
        public int IdPuc { get; set; }
    }

     public class EjecutaValidador : AbstractValidator<Ejecuta>
    {
        public EjecutaValidador()
        {
            RuleFor(x=>x.id_notaaclaratoria).NotEmpty();
            RuleFor(x=>x.IdPuc).NotEmpty();

        }
    }

    public class Manejador : IRequestHandler<Ejecuta>
    {
        private readonly CntContext _context;

        public Manejador(CntContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
        {
            var nota = new CntNotaAclaratoriaCuenta{
                
                IdNotaaclaratoria = request.id_notaaclaratoria,
                IdPuc = request.IdPuc                    
            };

            _context.cntNotaAclaratoriaCuentas.Add(nota);
            var valor = await _context.SaveChangesAsync();

            if(valor > 0){
                return Unit.Value;
            }

            throw new System.Exception("No se pudo insertar la nota aclarotia Cuenta");
        }
    }
}