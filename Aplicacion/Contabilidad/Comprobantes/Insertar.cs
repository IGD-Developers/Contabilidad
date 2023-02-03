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

namespace Aplicacion.Contabilidad.Comprobantes;

public class Insertar
{

    public class Ejecuta : InsertarComprobantesModel, IRequest
    {

    }

    public class EjecutaValidador : AbstractValidator<Ejecuta>
    {
        public EjecutaValidador()
        {
            RuleFor(x => x.IdSucursal).NotEmpty();
            RuleFor(x => x.IdTipocomprobante).NotEmpty();
            RuleFor(x => x.IdTercero).NotEmpty();
            RuleFor(x => x.CcoFecha).NotEmpty();
            RuleFor(x => x.CcoDocumento).NotEmpty();
            RuleFor(x => x.CcoDetalle).NotEmpty();
            RuleFor(x => x.IdUsuario).NotEmpty();

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

            //TODO:  MARIA Validar "IdSucursal", "IdTipocomprobante",  "IdTercero","IdUsuario", "IdCentrocosto", "IdPuc" "IdTercero" 
            //TODO: MARIA Asignar "IdModulo" según  el modulo

            var transaction = _context.Database.BeginTransaction();

            try
            {
                var respuestacc = await _insertarComprobante.Insertar(request);

                transaction.Commit();
                return Unit.Value;



            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar Comprobante catch " + ex.Message);

            }




        }
    }

}
