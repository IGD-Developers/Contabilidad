using Persistencia;
using Dominio.Contabilidad;
using System;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Contabilidad.Consecutivos;

public class Insertar
{
    

    public class Ejecuta : IRequest<CntConsecutivo> 
    {

        public int id_tipocomprobante { get; set; }

        public DateTime fecha { get; set; }

    }

   

    public class Manejador : IRequestHandler<Ejecuta, CntConsecutivo> 
    {
        private readonly CntContext context;

        public Manejador(CntContext context)
        {
            this.context = context;
        }





        public async Task<CntConsecutivo> Handle(Ejecuta request, CancellationToken cancellationToken)
        {
            var tipo = await context.cntTipoComprobantes
            .FirstOrDefaultAsync(t => t.id == request.id_tipocomprobante);
            if (tipo == null)
            {
                throw new Exception("Tipo de comprobante no encontrado");
            };

            var consecutivo = new CntConsecutivo
            {
                id_tipocomprobante = request.id_tipocomprobante,
                co_ano = "0000",
                co_mes = "00",
                co_consecutivo = 0
            };
            string ano = request.fecha.Year.ToString();
            string mes = request.fecha.Month.ToString();

            if (tipo.tco_incremento == "A")
            {
                consecutivo.co_ano = ano;
            }
            else if (tipo.tco_incremento == "M")
            {
                consecutivo.co_ano = ano;
                consecutivo.co_mes = mes;
            }
            else
            {

            }


            var consecutivoActual = await context.cntConsecutivos
            .FirstOrDefaultAsync(t => (t.id == request.id_tipocomprobante)
                                   && (t.co_ano == consecutivo.co_ano)
                                   && (t.co_mes == consecutivo.co_mes));



            if (consecutivoActual == null)
            {
                //  Insertamos un registro nuevo;
                consecutivo.co_consecutivo = 1;
                await context.cntConsecutivos.AddAsync(consecutivo);




            }
            else
            {
                //Sobreescribimos registro
                int nuevoid = consecutivoActual.co_consecutivo + 1;
                consecutivo.co_consecutivo = nuevoid;


            };
            var resultado = await context.SaveChangesAsync();
            if (resultado > 0)
            {
                return consecutivo;
            }

            throw new Exception("Error al modificar registro");
        }
    }

}