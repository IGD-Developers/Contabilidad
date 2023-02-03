using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Persistencia;

namespace Aplicacion.Contabilidad.Meses
{
    public class Editar
    {
        public class Ejecuta : IRequest{
            public int Id { get; set; }
            public int? mes_ano { get; set; }
            public int? mes_mes { get; set; }
            public bool? mes_cerrado { get; set; }
            public string id_usuario { get; set; }
            
        }

        public class EjecutaValidador : AbstractValidator<Ejecuta>
        {
            public EjecutaValidador()
            {
                RuleFor(x=>x.Id).NotEmpty();
                RuleFor(x=>x.mes_ano).NotEmpty();
                RuleFor(x=>x.mes_mes).NotEmpty();
                RuleFor(x=>x.mes_cerrado).NotEmpty();
                RuleFor(x=>x.id_usuario).NotEmpty();
                
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
                var cierre = await _context.cntMeses.FindAsync(request.Id);
                
                if(cierre==null){
                    throw new Exception("No se encontró cierre");
                }

                cierre.MesMes = request.mes_mes ?? cierre.MesMes;
                cierre.MesAno = request.mes_ano ?? cierre.MesAno;
                cierre.MesCerrado = request.mes_cerrado ?? cierre.MesCerrado;
                // if (request.id_usuario!=null){
                //     cierre.id_usuario = request.id_usuario;
                // };
                //cierre.id_usuario = request.id_usuario ?? cierre.id_usuario;
                cierre.IdUsuario = request.id_usuario;

               // _context.Add(cierre);
                var resultado = await _context.SaveChangesAsync();

                if(resultado>0){
                    return Unit.Value;
                }

                throw new Exception("No se pudo editar el cierre");


            }
        }
    }
}