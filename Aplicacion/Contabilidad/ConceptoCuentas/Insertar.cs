using Persistencia;
using Dominio.Contabilidad;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace Aplicacion.Contabilidad.ConceptoCuentas
{
    public class Insertar
    {
        public class Ejecuta: IRequest
        {

            public int id_exogenaconcepto { get; set; }
            public int IdPuc { get; set; }
            public int id_formatocolumna { get; set; }
            public int id_tipooperacion { get; set; }
            public string Estado { get; set; }
        }

        public class Manejador:IRequestHandler<Ejecuta>
        {
            private readonly CntContext context;

            public Manejador(CntContext context)
            {
                this.context = context;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var conceptoCuenta=new CntConceptoCuenta
                {
                    IdExogenaconcepto =request.id_exogenaconcepto,
                    IdPuc =request.IdPuc,
                    IdFormatocolumna=request.id_formatocolumna,
                    IdTipooperacion =request.id_tipooperacion,
                    Estado=request.Estado
                };
                context.cntConceptoCuentas.Add(conceptoCuenta);
                var respuesta= await context.SaveChangesAsync();
                if (respuesta>0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error 112 al insertar conceptocuenta");
            }
        }
        
    }
}