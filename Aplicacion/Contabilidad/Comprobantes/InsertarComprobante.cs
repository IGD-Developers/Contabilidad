using System;
using System.Threading.Tasks;
using Aplicacion.Contabilidad.Consecutivos;
using Aplicacion.Models.Contabilidad.Comprobantes;
using Aplicacion.Models.Contabilidad.Consecutivos;
using Aplicacion.Models.Contabilidad.DetalleComprobantes;
using AutoMapper;
using Dominio.Contabilidad;
using MediatR;
using Persistencia;

namespace Aplicacion.Contabilidad.Comprobantes
{
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
                id_tipocomprobante = model.id_tipocomprobante,
                fecha = model.cco_fecha,
                id_sucursal = model.id_sucursal
            };



            var resu = await _insertarConsecutivo.Insertar(cns);
            System.Console.WriteLine(resu);
            model.cco_ano = resu.CoAno;
            model.cco_mes = resu.CoMes;
            model.cco_consecutivo = resu.CoConsecutivo;

            IdComprobanteModel idComprobante = new IdComprobanteModel{Id = -1};
            var entidadDto = _mapper.Map<InsertarComprobantesModel, CntComprobante>(model);
            if(entidadDto.Tcredito!=entidadDto.Tdebito)
            {
                
                 throw new Exception("Los Débitos y Créditos no son iguales" );
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

                if (model.comprobanteDetalleComprobantes != null)
                {
                    foreach (InsertarDetalleComprobanteModel registro in model.comprobanteDetalleComprobantes)
                    {
                        registro.id_comprobante = nuevoid;
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

                throw new System.NotImplementedException();
            }
             catch (Exception ex)
                {

                    throw new Exception("Error al insertar comprobante catch " + ex.Message);
                }

        }
    }

}
//          ConsecutivoComprobanteModel cns = new ConsecutivoComprobanteModel
//                 {
//                     id_tipocomprobante = request.id_tipocomprobante,
//                     fecha = request.cco_fecha,
//                     id_sucursal = request.id_sucursal
//                 };
//                 var transaction = context.Database.BeginTransaction();
//                 try
//                 {

//                     var resu = await insertarConsecutivo.Insertar(cns);
//                     System.Console.WriteLine(resu);
//                     request.cco_ano = resu.co_ano;
//                     request.cco_mes = resu.co_mes;
//                     request.cco_consecutivo = resu.co_consecutivo;

//                     var entidadDto = _mapper.Map<InsertarComprobantesModel, CntComprobante>(request);

//                     await context.cntComprobantes.AddAsync(entidadDto);
//                     var respuesta1 = await context.SaveChangesAsync();
//                     int nuevoid = entidadDto.id;
//                     Console.WriteLine(nuevoid);

//                     if (request.detalleComprobante != null)
//                     {
//                         foreach (InsertarDetalleComprobanteModel registro in request.detalleComprobante)
//                         {
//                             registro.id_comprobante = nuevoid;
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

//                     throw new Exception("Error al insertar comprobante");
//                 }
//                 catch (Exception ex)
//                 {

//                     throw new Exception("Error al insertar comprobante catch " + ex.Message);
//                 }

//                 // throw new Exception("Error al insertar comprobante");
//             }
//     }
// }