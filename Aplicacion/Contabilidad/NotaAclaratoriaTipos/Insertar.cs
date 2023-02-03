using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Dominio.Contabilidad;
using FluentValidation;
using MediatR;
using Persistencia;

namespace Aplicacion.Contabilidad.NotaAclaratoriaTipos
{
    public class Insertar
    {
        public class Ejecuta : IRequest{

            [StringLength(3, MinimumLength =3, ErrorMessage ="Debe ingresar solo 3 caracteres")]
            public string codigo { get; set; }
            public string nombre { get; set; }
            
        }

        public class EjecutaValidador : AbstractValidator<Ejecuta>
        {
            public EjecutaValidador()
            {
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
                var nota = new CntNotaAclaratoriaTipo{
                    Codigo = request.codigo,
                    Nombre = request.nombre
                };

                _context.cntNotaAclaratoriaTipos.Add(nota);
                var valor = await _context.SaveChangesAsync();

                if(valor > 0){
                    return Unit.Value;
                }

                throw new Exception("No se pudo insertar la nota aclaratoria tipo");
                
            }
        }
    }
}