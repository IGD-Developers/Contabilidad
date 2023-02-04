using System;
using System.Threading;
using System.Threading.Tasks;
using ContabilidadWebAPI.Persistencia;
using FluentValidation;
using MediatR;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.NotaAclaratoriaCuentas;

public class Editar
{
    public class Ejecuta : IRequest
    {
        public int Id { get; set; }
        public int? id_notaaclaratoria { get; set; }
        public int? IdPuc { get; set; }
    }

    public class EjecutaValidador : AbstractValidator<Ejecuta>
    {
        public EjecutaValidador()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.id_notaaclaratoria).NotEmpty();
            RuleFor(x => x.IdPuc).NotEmpty();

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
            var nota = await _context.cntNotaAclaratoriaCuentas.FindAsync(request.Id);

            if (nota == null)
            {
                throw new Exception("No se encontro nota");
            }

            nota.IdNotaaclaratoria = request.id_notaaclaratoria ?? nota.IdNotaaclaratoria;
            nota.IdPuc = request.IdPuc ?? nota.IdPuc;

            var resultado = await _context.SaveChangesAsync();

            if (resultado > 0)
            {
                return Unit.Value;
            }

            throw new Exception("No se pudo editar la nota");

        }
    }
}