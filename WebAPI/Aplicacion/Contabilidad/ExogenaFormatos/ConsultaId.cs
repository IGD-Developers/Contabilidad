using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using ContabilidadWebAPI.Persistencia;
using ContabilidadWebAPI.Dominio.Contabilidad;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.ExogenaFormatos;

public class ConsultaId
{

    public class ConsultarId : IRequest<CntExogenaFormato>
    {

        public int Id { get; set; }
    }

    public class Manejador : IRequestHandler<ConsultarId, CntExogenaFormato>
    {
        private readonly CntContext context;

        public Manejador(CntContext context)
        {
            this.context = context;
        }

        public async Task<CntExogenaFormato> Handle(ConsultarId request, CancellationToken cancellationToken)
        {
            var exogenaFormato = await context.cntExogenaFormatos.FindAsync(request.Id);
            if (exogenaFormato == null)
            {
                throw new Exception("Registro no encontrado");
            };

            return exogenaFormato;
        }
    }

}