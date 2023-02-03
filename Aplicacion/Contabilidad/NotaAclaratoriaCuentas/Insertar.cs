using System.Threading;
using System.Threading.Tasks;
using Dominio.Contabilidad;
using FluentValidation;
using MediatR;
using Persistencia;

namespace Aplicacion.Contabilidad.NotaAclaratoriaCuentas
{
    public class Insertar
    {
        public class Ejecuta : IRequest{
            public int id_notaaclaratoria { get; set; }
            public int id_puc { get; set; }
        }

         public class EjecutaValidador : AbstractValidator<Ejecuta>
        {
            public EjecutaValidador()
            {
                RuleFor(x=>x.id_notaaclaratoria).NotEmpty();
                RuleFor(x=>x.id_puc).NotEmpty();

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
                    
                    id_notaaclaratoria = request.id_notaaclaratoria,
                    id_puc = request.id_puc                    
                };

                _context.cntNotaAclaratoriaCuentas.Add(nota);
                var valor = await _context.SaveChangesAsync();

                if(valor > 0){
                    return Unit.Value;
                }

                throw new System.Exception("No se pudo insertar la nota aclarotia cuenta");
            }
        }
    }
}