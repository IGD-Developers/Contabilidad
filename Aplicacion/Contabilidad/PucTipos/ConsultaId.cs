using MediatR;
using Persistencia;
using System.Threading.Tasks;
using System.Threading;
using Dominio.Contabilidad;
using System;
using Aplicacion.Models.Contabilidad.PucTipos;

namespace Aplicacion.Contabilidad.PucTipos
{
    public class ConsultaId
    {

        public class ConsultarId : IdPucTipoModel,IRequest<CntPucTipo>
        {   }


        public class Manejador : IRequestHandler<ConsultarId, CntPucTipo>
        {

            private readonly CntContext context;

            public Manejador(CntContext context)
            {
                this.context = context;
            }

            public async Task<CntPucTipo> Handle(ConsultarId request, CancellationToken cancellationToken)
            {

                var PucTipo = await context.cntPucTipos.FindAsync(request.Id);
               if (PucTipo == null) {  
                    throw new Exception("Registro no encontrado");
                };                    
                return PucTipo;

            }


        }

    }
}