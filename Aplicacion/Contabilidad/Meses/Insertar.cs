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
        public string IdUsuario { get; set; }
        
    }

    public class EjecutaValidador : AbstractValidator<Ejecuta>
    {
        public EjecutaValidador()
        {
            RuleFor(x=>x.mes_ano).NotEmpty();
            RuleFor(x=>x.mes_mes).NotEmpty();
            RuleFor(x=>x.mes_cerrado).NotEmpty();
            RuleFor(x=>x.IdUsuario).NotEmpty();
            
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
                MesAno = request.mes_ano,
                MesMes = request.mes_mes,
                MesCerrado = request.mes_cerrado,
                IdUsuario = request.IdUsuario

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