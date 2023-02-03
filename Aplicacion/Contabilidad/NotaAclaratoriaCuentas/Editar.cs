using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Persistencia;

namespace Aplicacion.Contabilidad.NotaAclaratoriaCuentas
{
    public class Editar
    {
        public class Ejecuta : IRequest {
            public int id { get; set; }
            public int? id_notaaclaratoria { get; set; }
            public int? id_puc { get; set; }
        }

         public class EjecutaValidador : AbstractValidator<Ejecuta>
        {
            public EjecutaValidador()
            {
                RuleFor(x=>x.id).NotEmpty();
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
                var nota = await _context.cntNotaAclaratoriaCuentas.FindAsync(request.id);

                if(nota == null){
                    throw new Exception("No se encontro nota");
                }

                nota.id_notaaclaratoria = request.id_notaaclaratoria ?? nota.id_notaaclaratoria;
                nota.id_puc = request.id_puc ?? nota.id_puc;

                var resultado = await _context.SaveChangesAsync();

                if(resultado>0){
                    return Unit.Value;
                }

                throw new Exception("No se pudo editar la nota");

            }
        }
    }
}