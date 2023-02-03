using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Persistencia;

namespace Aplicacion.Contabilidad.NotaAclaratoriaTipos
{
    public class Editar
    {
        public class Ejecuta : IRequest{
            public int id { get; set; }
            public string codigo { get; set; }
            public string nombre { get; set; }
        }

        public class EjecutaValidador : AbstractValidator<Ejecuta>
        {
            public EjecutaValidador()
            {
                RuleFor(x=>x.id).NotEmpty();
                RuleFor(x=>x.codigo).NotEmpty();
                RuleFor(x=>x.nombre).NotEmpty();

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
                var nota = await _context.cntNotaAclaratoriaTipos.FindAsync(request.id);

                if(nota == null){
                    throw new Exception("No se encontro nota aclaratoria tipo");
                }

                nota.Nombre = request.nombre ?? nota.Nombre;
                nota.Codigo = request.codigo ?? nota.Codigo;

                var resultado = await _context.SaveChangesAsync();

                if(resultado>0){
                    return Unit.Value;
                }

                throw new Exception("No se ppudo editar la nota aclaratoria tipo");


            }
        }
    }
}