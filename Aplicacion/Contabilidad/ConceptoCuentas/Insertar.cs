using Persistencia;
using Dominio.Contabilidad;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace Aplicacion.Contabilidad.ConceptoCuentas;

public class Insertar
{
    public class Ejecuta: IRequest
    {

        public int id_exogenaconcepto { get; set; }
        public int id_puc { get; set; }
        public int id_formatocolumna { get; set; }
        public int id_tipooperacion { get; set; }
        public string estado { get; set; }
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
                id_exogenaconcepto =request.id_exogenaconcepto,
                id_puc =request.id_puc,
                id_formatocolumna=request.id_formatocolumna,
                id_tipooperacion =request.id_tipooperacion,
                estado=request.estado
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