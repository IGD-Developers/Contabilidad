using System;
using System.Threading;
using System.Threading.Tasks;
using Dominio.Contabilidad;
using FluentValidation;
using MediatR;
using Persistencia;

namespace Aplicacion.Contabilidad.Meses;

public class Insertar
{
    public class Ejecuta : IRequest{
        public int mes_ano { get; set; }
        public int mes_mes { get; set; }
        public bool mes_cerrado { get; set; }
        public string id_usuario { get; set; }
        
    }

    public class EjecutaValidador : AbstractValidator<Ejecuta>
    {
        public EjecutaValidador()
        {
            RuleFor(x=>x.mes_ano).NotEmpty();
            RuleFor(x=>x.mes_mes).NotEmpty();
            RuleFor(x=>x.mes_cerrado).NotEmpty();
            RuleFor(x=>x.id_usuario).NotEmpty();
            
        }
    }

    public class Manejador : IRequestHandler<Ejecuta>
    {
        public readonly CntContext _context;

        public Manejador(CntContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
        {
            var mes = new CntMes{
                mes_ano = request.mes_ano,
                mes_mes = request.mes_mes,
                mes_cerrado = request.mes_cerrado,
                id_usuario = request.id_usuario

            };

            _context.cntMeses.Add(mes);
            var valor = await _context.SaveChangesAsync();

            if(valor > 0){
                return Unit.Value;
            }

            throw new Exception("No se pudo insertar el Mes");
        }
    }
    
}