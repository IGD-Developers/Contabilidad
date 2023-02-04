using System;
using System.Threading.Tasks;
using AutoMapper;
using ContabilidadWebAPI.Aplicacion.Contabilidad.Consecutivos;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Comprobantes;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Consecutivos;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.DetalleComprobantes;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using MediatR;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Comprobantes;

public class InsertarComprobante : InsertarComprobantesModel, IInsertarComprobante
{

    private readonly CntContext _context;
    private readonly IMapper _mapper;
    private IInsertarConsecutivo _insertarConsecutivo;

    public InsertarComprobante(CntContext context, IMapper mapper, IInsertarConsecutivo insertarConsecutivo)
    {
        _context = context;
        _mapper = mapper;
        _insertarConsecutivo = insertarConsecutivo;
    }

    public async Task<IdComprobanteModel> Insertar(InsertarComprobantesModel model)
    {


        ConsecutivoComprobanteModel cns = new ConsecutivoComprobanteModel
        {
            IdTipocomprobante = model.IdTipocomprobante,
            Fecha = model.CcoFecha,
            IdSucursal = model.IdSucursal
        };



        var resu = await _insertarConsecutivo.Insertar(cns);
        Console.WriteLine(resu);
        model.CcoAno = resu.CoAno;
        model.CcoMes = resu.CoMes;
        model.CcoConsecutivo = resu.CoConsecutivo;

        IdComprobanteModel idComprobante = new IdComprobanteModel { Id = -1 };
        var entidadDto = _mapper.Map<InsertarComprobantesModel, CntComprobante>(model);
        if (entidadDto.Tcredito != entidadDto.Tdebito)
        {

            throw new Exception("Los Débitos y Créditos no son iguales");
            //Console.WriteLine("Los Débitos y Créditos no son iguales" );

        }
        //var transaction = _context.Database.BeginTransaction();

        try
        {


            await _context.cntComprobantes.AddAsync(entidadDto);
            var respuesta1 = await _context.SaveChangesAsync();
            int nuevoid = entidadDto.Id;
            idComprobante.Id = nuevoid;
            Console.WriteLine(nuevoid);

            if (model.ComprobanteDetalleComprobantes != null)
            {
                foreach (InsertarDetalleComprobanteModel registro in model.ComprobanteDetalleComprobantes)
                {
                    registro.IdComprobante = nuevoid;
                    var detalleDto = _mapper.Map<InsertarDetalleComprobanteModel, CntDetalleComprobante>(registro);

                    _context.cntDetalleComprobantes.Add(detalleDto);

                }
                var respuesta2 = await _context.SaveChangesAsync();
                if (respuesta2 > 0)
                {

                    //transaction.Commit();
                    //return Unit.Value;
                    // IdComprobanteModel idComprobante = new IdComprobanteModel
                    // {Id = nuevoid};
                    return idComprobante;

                }

            }

            throw new NotImplementedException();
        }
        catch (Exception ex)
        {

            throw new Exception("Error al insertar Comprobante catch " + ex.Message);
        }

    }
}
//          ConsecutivoComprobanteModel cns = new ConsecutivoComprobanteModel
//                 {
//                     IdTipocomprobante = request.IdTipocomprobante,
//                     Fecha = request.CcoFecha,
//                     IdSucursal = request.IdSucursal
//                 };
//                 var transaction = context.Database.BeginTransaction();
//                 try
//                 {

//                     var resu = await insertarConsecutivo.Insertar(cns);
//                     System.Console.WriteLine(resu);
//                     request.CcoAno = resu.CoAno;
//                     request.CcoMes = resu.CoMes;
//                     request.CcoConsecutivo = resu.CoConsecutivo;

//                     var entidadDto = _mapper.Map<InsertarComprobantesModel, CntComprobante>(request);

//                     await context.cntComprobantes.AddAsync(entidadDto);
//                     var respuesta1 = await context.SaveChangesAsync();
//                     int nuevoid = entidadDto.Id;
//                     Console.WriteLine(nuevoid);

//                     if (request.detalleComprobante != null)
//                     {
//                         foreach (InsertarDetalleComprobanteModel registro in request.detalleComprobante)
//                         {
//                             registro.IdComprobante = nuevoid;
//                             var detalleDto = _mapper.Map<InsertarDetalleComprobanteModel, CntDetalleComprobante>(registro);

//                             context.cntDetalleComprobantes.Add(detalleDto);

//                         }
//                         var respuesta2 = await context.SaveChangesAsync();
//                         if (respuesta2 > 0)
//                         {

//                             transaction.Commit();
//                             return Unit.Value;

//                         }

//                     }

//                     throw new Exception("Error al insertar Comprobante");
//                 }
//                 catch (Exception ex)
//                 {

//                     throw new Exception("Error al insertar Comprobante catch " + ex.Message);
//                 }

//                 // throw new Exception("Error al insertar Comprobante");
//             }
//     }
// }