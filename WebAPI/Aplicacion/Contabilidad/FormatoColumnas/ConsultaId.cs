using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.FormatoColumnas;

public class ConsultaId
{

    public class ConsultarId : IRequest<CntFormatoColumna>
    {
        public int Id { get; set; }
    }


    public class Manejador : IRequestHandler<ConsultarId, CntFormatoColumna>
    {
        private readonly CntContext context;

        public Manejador(CntContext context)
        {
            this.context = context;
        }

        public async Task<CntFormatoColumna> Handle(ConsultarId request, CancellationToken cancellationToken)
        {
            var formatoColumna = await context.cntFormatoColumnas.FindAsync(request.Id);
            if (formatoColumna == null)
            {
                throw new Exception("Registro no encontrado");
            };

            return formatoColumna;

        }
    }

}