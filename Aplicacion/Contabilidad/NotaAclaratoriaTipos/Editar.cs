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
            public int Id { get; set; }
            public string Codigo { get; set; }
            public string Nombre { get; set; }
        }

        public class EjecutaValidador : AbstractValidator<Ejecuta>
        {
            public EjecutaValidador()
            {
                RuleFor(x=>x.Id).NotEmpty();
                RuleFor(x=>x.Codigo).NotEmpty();
                RuleFor(x=>x.Nombre).NotEmpty();

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
                var nota = await _context.cntNotaAclaratoriaTipos.FindAsync(request.Id);

                if(nota == null){
                    throw new Exception("No se encontro nota aclaratoria tipo");
                }

                nota.Nombre = request.Nombre ?? nota.Nombre;
                nota.Codigo = request.Codigo ?? nota.Codigo;

                var resultado = await _context.SaveChangesAsync();

                if(resultado>0){
                    return Unit.Value;
                }

                throw new Exception("No se ppudo editar la nota aclaratoria tipo");


            }
        }
    }
}