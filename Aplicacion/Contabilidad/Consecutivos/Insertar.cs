using Persistencia;
using Dominio.Contabilidad;
using System;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Contabilidad.Consecutivos
{
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
                .FirstOrDefaultAsync(t => t.Id == request.id_tipocomprobante);
                if (tipo == null)
                {
                    throw new Exception("Tipo de comprobante no encontrado");
                };

                var consecutivo = new CntConsecutivo
                {
                    IdTipocomprobante = request.id_tipocomprobante,
                    CoAno = "0000",
                    CoMes = "00",
                    CoConsecutivo = 0
                };
                string ano = request.fecha.Year.ToString();
                string mes = request.fecha.Month.ToString();

                if (tipo.TcoIncremento == "A")
                {
                    consecutivo.CoAno = ano;
                }
                else if (tipo.TcoIncremento == "M")
                {
                    consecutivo.CoAno = ano;
                    consecutivo.CoMes = mes;
                }
                else
                {

                }


                var consecutivoActual = await context.cntConsecutivos
                .FirstOrDefaultAsync(t => (t.Id == request.id_tipocomprobante)
                                       && (t.CoAno == consecutivo.CoAno)
                                       && (t.CoMes == consecutivo.CoMes));



                if (consecutivoActual == null)
                {
                    //  Insertamos un registro nuevo;
                    consecutivo.CoConsecutivo = 1;
                    await context.cntConsecutivos.AddAsync(consecutivo);




                }
                else
                {
                    //Sobreescribimos registro
                    int nuevoid = consecutivoActual.CoConsecutivo + 1;
                    consecutivo.CoConsecutivo = nuevoid;


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
}