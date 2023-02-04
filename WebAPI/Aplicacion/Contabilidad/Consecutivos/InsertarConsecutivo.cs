using System;
//using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Consecutivos;
using ContabilidadWebAPI.Persistencia;
using ContabilidadWebAPI.Dominio.Contabilidad;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Consecutivos;



public class InsertarConsecutivo : ConsecutivoComprobanteModel, IInsertarConsecutivo
{

    private readonly CntContext context;


    /// <summary>Class <c>InsertarConsecutivo</c> Esta Clase devuelve
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
            .FirstOrDefaultAsync(t => t.Id == model.IdTipocomprobante);
            if (tipo == null)
            {
                throw new Exception("Tipo de Comprobante no encontrado");
            };



            var consecutivo = new CntConsecutivo
            {
                IdTipocomprobante = model.IdTipocomprobante,
                CoAno = "0000",
                CoMes = "00",
                CoConsecutivo = 0,
                IdSucursal = model.IdSucursal
            };
            string ano = model.Fecha.Year.ToString();
            string mes = model.Fecha.Month.ToString();
            if (mes.Length == 1) mes = "0" + mes;


            if (tipo.TcoIncremento == "A")
            {
                consecutivo.CoAno = ano;
            }
            else if (tipo.TcoIncremento == "M")
            {
                consecutivo.CoAno = ano;
                consecutivo.CoMes = mes;
            }
            else if (tipo.TcoIncremento == "C")
            {
                consecutivo.CoAno = ano;
                consecutivo.CoMes = "13";
            }
            else
            {
                //Consecutivo Unico ano 000 mes 00
            }

            var consecutivoActual = await context.cntConsecutivos
            .FirstOrDefaultAsync(t => t.IdTipocomprobante == model.IdTipocomprobante
                                   && t.CoAno == consecutivo.CoAno
                                   && t.CoMes == consecutivo.CoMes
                                   && t.IdSucursal == consecutivo.IdSucursal
                                   );

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
                consecutivoActual.CoConsecutivo = nuevoid;
                consecutivo.CoConsecutivo = nuevoid;


            };


            return consecutivo;
        }
        catch (Exception)
        {
            throw new Exception("Error al modificar registro");
        }







    }

}
