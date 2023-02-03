using MediatR;
using Persistencia;
using Dominio.Contabilidad;
using System.Threading.Tasks;
using System.Threading;
using System;
using FluentValidation;
using Aplicacion.Models.Contabilidad.TipoImpuestos;
using AutoMapper;

namespace Aplicacion.Contabilidad.TipoImpuestos
{
    public class Insertar
    {

        public class Ejecuta : InsertarTipoImpuestosModel, IRequest
        { }

        public class EjecutaValidador : AbstractValidator<Ejecuta>
        {
            public EjecutaValidador()
            {
                RuleFor(x => x.Codigo).NotEmpty();
                RuleFor(x => x.Nombre).NotEmpty();

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

                //Como vamos a grabar primero el modelo y luego la entidad:
                try
                {
                    var entidadDto = _mapper.Map<InsertarTipoImpuestosModel, CntTipoImpuesto>(request);

                    await _context.cntTipoImpuestos.AddAsync(entidadDto);
                    var respuesta = await _context.SaveChangesAsync();
                    if (respuesta > 0)
                    {

                        return Unit.Value;
                    }
                    throw new Exception("Error al insertar Registro");
                }
                catch (Exception ex)
                {
                    //TODO: MARIA  Llave duplicada  CODIGO TIPOIMPUESTO Implementar
                    throw new Exception("Error al Insertar registro catch " + ex.Message);

                }



            }
        }

    }
}