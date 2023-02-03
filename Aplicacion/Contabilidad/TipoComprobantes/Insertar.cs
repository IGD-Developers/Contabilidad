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

namespace Aplicacion.Contabilidad.TipoComprobantes
{
    public class Insertar
    {
        public class Ejecuta : InsertarTipoComprobanteModel, IRequest
        { }

        public class EjecutaValidador : AbstractValidator<Ejecuta>
        {
            public EjecutaValidador()
            {
                RuleFor(x => x.id_categoriacomprobante).NotEmpty();
                RuleFor(x => x.codigo).NotEmpty();
                RuleFor(x => x.nombre).NotEmpty();
                RuleFor(x => x.tco_incremento).NotEmpty();
                RuleFor(x => x.tco_incremento).Matches("^[A,U,M]+");

                // RuleFor(x=>x.editable).NotEmpty();
                // RuleFor(x=>x.anulable).NotEmpty();
                RuleFor(x => x.id_usuario).NotEmpty();

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

                //TODO: MARIA Validaciones id_usuario 
                //TODO: MARIA Liberar de memoria para volver a utilizar entidad No me permite usar el mismo nombre 
                using (var entidad = await _context.cntCategoriaComprobantes.SingleOrDefaultAsync(t => t.id == request.id_categoriacomprobante))
                {
                    if (entidad == null)
                    {
                        throw new Exception("Categoría  no encontrada");
                    };
                }

                try
                {
                    var entidad2 = await _context.cntCategoriaComprobantes
                   .SingleOrDefaultAsync(t => t.id == request.id_categoriacomprobante);

                    if (entidad2 == null)
                    {
                        throw new Exception("Categoría  no encontrada");
                    };


                    var entidadDto = _mapper.Map<InsertarTipoComprobanteModel, CntTipoComprobante>(request);


                    _context.cntTipoComprobantes.Add(entidadDto);
                    var respuesta = await _context.SaveChangesAsync();
                    //TODO: MARIA LLave Duplicada codigo tipocomprobante Implementar

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
    // var tipoComprobante = new CntTipoComprobante {
    //     id_categoriacomprobante = request.id_categoriacomprobante,
    //     codigo = request.codigo,
    //     nombre = request.nombre,  
    //     tco_incremento  = request.tco_incremento,
    //     editable = request.editable,  
    //     anulable = request.anulable,  
    //     id_usuario = request.id_usuario 
    // };

}
