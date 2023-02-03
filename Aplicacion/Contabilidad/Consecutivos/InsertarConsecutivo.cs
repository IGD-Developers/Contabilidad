using Persistencia;
using Dominio.Contabilidad;
using System;
//using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Aplicacion.Models.Contabilidad.Consecutivos;

namespace Aplicacion.Contabilidad.Consecutivos;


    
public class InsertarConsecutivo : ConsecutivoComprobanteModel,IInsertarConsecutivo
{

    private readonly CntContext context;
    

    /// <summary>Class <c>InsertarConsecutivo</c> Esta clase devuelve
    /// El Consecutivo generado a partir del tipo de Incremento de cntTipoComprobante.</summary>
    public InsertarConsecutivo(CntContext context)
    {
        this.context = context;
    }

    public async Task<CntConsecutivo> Insertar(ConsecutivoComprobanteModel model)
    {
        try
        {
            var tipo = await context.cntTipoComprobantes
            .FirstOrDefaultAsync(t => t.id == model.id_tipocomprobante);
            if (tipo == null)
            {
                throw new Exception("Tipo de comprobante no encontrado");
            };



            var consecutivo = new CntConsecutivo
            {
                id_tipocomprobante = model.id_tipocomprobante,
                co_ano = "0000",
                co_mes = "00",
                co_consecutivo = 0,
                id_sucursal =model.id_sucursal
            };
            string ano = model.fecha.Year.ToString();
            string mes = model.fecha.Month.ToString();
            if (mes.Length ==1)  mes="0"+mes;
            

            if (tipo.tco_incremento == "A")
            {
                consecutivo.co_ano = ano;
            }
            else if (tipo.tco_incremento == "M")
            {
                consecutivo.co_ano = ano;
                consecutivo.co_mes = mes;
            }
            else if (tipo.tco_incremento == "C")
            {
                consecutivo.co_ano = ano;
                consecutivo.co_mes = "13";
            }
            else
            {
            //Consecutivo Unico ano 000 mes 00
            }

            var consecutivoActual = await context.cntConsecutivos
            .FirstOrDefaultAsync(t => (t.id_tipocomprobante == model.id_tipocomprobante)
                                   && (t.co_ano == consecutivo.co_ano)
                                   && (t.co_mes == consecutivo.co_mes)
                                   && (t.id_sucursal == consecutivo.id_sucursal)
                                   );

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
                consecutivoActual.co_consecutivo = nuevoid;
                consecutivo.co_consecutivo = nuevoid;


            };

            
            return consecutivo;
        }
        catch (Exception)
        {
            throw new Exception("Error al modificar registro");
        }







    }

}
