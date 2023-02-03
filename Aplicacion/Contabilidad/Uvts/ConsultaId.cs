using MediatR;
using Persistencia;
using Dominio.Contabilidad;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace Aplicacion.Contabilidad.Uvts;

public class ConsultaId
{

    public class ConsultarId: IRequest<CntUvt> {

        public int Id { get; set; }
    }

    public class Manejador : IRequestHandler<ConsultarId, CntUvt>
    {
        private readonly CntContext context;

        public Manejador(CntContext context)
        {
            this.context = context;
        }

        public async Task<CntUvt> Handle(ConsultarId request, CancellationToken cancellationToken)
        {
            var uvt = await context.cntUvts.FindAsync(request.Id);
            if (uvt == null) {  
                    throw new Exception("Registro no encontrado");
            };                   

            return uvt;
        }
    }



}