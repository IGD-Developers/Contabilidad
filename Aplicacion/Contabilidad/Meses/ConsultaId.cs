using MediatR;
using Persistencia;
using System.Threading.Tasks;
using System.Threading;
using Dominio.Contabilidad;
using System;

namespace Aplicacion.Contabilidad.Meses;

public class ConsultaId
{

    public class ConsultarId : IRequest<CntMes>
    {
        public int Id { get; set; }
    }

    public class Manejador : IRequestHandler<ConsultarId, CntMes>
    {
        private readonly CntContext context;

        public Manejador(CntContext context)
        {
            this.context = context;
        }

        public async Task<CntMes> Handle(ConsultarId request, CancellationToken cancellationToken)
        {
            var mes = await context.cntMeses.FindAsync(request.Id);
          if (mes == null) {  
                throw new Exception("Registro no encontrado");
            };                

            return mes;
        }
    }

}