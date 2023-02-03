using Persistencia;
using Dominio.Contabilidad;
using MediatR;
using System;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;
using Aplicacion.Models.Contabilidad.Comprobantes;
using Aplicacion.Models.Contabilidad.DetalleComprobantes;
using Aplicacion.Contabilidad.Consecutivos;
using Aplicacion.Models.Contabilidad.Consecutivos;
using Aplicacion.Interfaces;
using AutoMapper;

namespace Aplicacion.Contabilidad.Comprobantes
{
    public class Insertar
    {

        public class Ejecuta : InsertarComprobantesModel, IRequest
        {

        }

        public class EjecutaValidador : AbstractValidator<Ejecuta>
        {
            public EjecutaValidador()
            {
                RuleFor(x => x.id_sucursal).NotEmpty();
                RuleFor(x => x.id_tipocomprobante).NotEmpty();
                RuleFor(x => x.id_tercero).NotEmpty();
                RuleFor(x => x.cco_fecha).NotEmpty();
                RuleFor(x => x.cco_documento).NotEmpty();
                RuleFor(x => x.cco_detalle).NotEmpty();
                RuleFor(x => x.id_usuario).NotEmpty();

            }
        }



        public class Manejador : IRequestHandler<Ejecuta>
        {

            private readonly IMapper _mapper;
            private IInsertarComprobante _insertarComprobante;
            private readonly CntContext _context;

            public Manejador(CntContext context, IInsertarComprobante insertarComprobante, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
                _insertarComprobante = insertarComprobante;

            }


            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {

                //TODO:  MARIA Validar "id_sucursal", "id_tipocomprobante",  "id_tercero","id_usuario", "id_centrocosto", "id_puc" "id_tercero" 
                //TODO: MARIA Asignar "id_modulo" según  el modulo

                var transaction = _context.Database.BeginTransaction();

                try
                {
                    var respuestacc = await _insertarComprobante.Insertar(request);

                    transaction.Commit();
                    return Unit.Value;



                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar comprobante catch " + ex.Message);

                }




            }
        }

    }


}
