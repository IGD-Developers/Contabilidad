using MediatR;
using Persistencia;
using Dominio.Contabilidad;
using System;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;
using Aplicacion.Models.Contabilidad.TipoComprobantes;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Contabilidad.TipoComprobantes;

public class Insertar
{
    public class Ejecuta : InsertarTipoComprobanteModel, IRequest
    { }

    public class EjecutaValidador : AbstractValidator<Ejecuta>
    {
        public EjecutaValidador()
        {
            RuleFor(x => x.IdCategoriacomprobante).NotEmpty();
            RuleFor(x => x.Codigo).NotEmpty();
            RuleFor(x => x.Nombre).NotEmpty();
            RuleFor(x => x.TcoIncremento).NotEmpty();
            RuleFor(x => x.TcoIncremento).Matches("^[A,U,M]+");

            // RuleFor(x=>x.Editable).NotEmpty();
            // RuleFor(x=>x.Anulable).NotEmpty();
            RuleFor(x => x.IdUsuario).NotEmpty();

        }
    }


    public class Manejador : IRequestHandler<Ejecuta>
    {

        private CntContext _context;
        private readonly IMapper _mapper;



        public Manejador(CntContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
        {

            //TODO: MARIA Validaciones IdUsuario 
            //TODO: MARIA Liberar de memoria para volver a utilizar entidad No me permite usar el mismo Nombre 
            using (var entidad = await _context.cntCategoriaComprobantes.SingleOrDefaultAsync(t => t.Id == request.IdCategoriacomprobante))
            {
                if (entidad == null)
                {
                    throw new Exception("Categoría  no encontrada");
                };
            }

            try
            {
                var entidad2 = await _context.cntCategoriaComprobantes
               .SingleOrDefaultAsync(t => t.Id == request.IdCategoriacomprobante);

                if (entidad2 == null)
                {
                    throw new Exception("Categoría  no encontrada");
                };


                var entidadDto = _mapper.Map<InsertarTipoComprobanteModel, CntTipoComprobante>(request);


                _context.cntTipoComprobantes.Add(entidadDto);
                var respuesta = await _context.SaveChangesAsync();
                //TODO: MARIA LLave Duplicada Codigo tipocomprobante Implementar

                if (respuesta > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al insertar Registro");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Insertar registro catch " + ex.Message);
            }
        }
    }

}
// var TipoComprobante = new CntTipoComprobante {
//     IdCategoriacomprobante = request.IdCategoriacomprobante,
//     Codigo = request.Codigo,
//     Nombre = request.Nombre,  
//     TcoIncremento  = request.TcoIncremento,
//     Editable = request.Editable,  
//     Anulable = request.Anulable,  
//     IdUsuario = request.IdUsuario 
// };
