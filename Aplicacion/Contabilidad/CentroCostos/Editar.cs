using MediatR;
using Persistencia;
using System;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;
using AutoMapper;
using Aplicacion.Models.Contabilidad.CentroCostos;
using Dominio.Contabilidad;

namespace Aplicacion.Contabilidad.CentroCostos
{
    public class Editar
    {

        public class Ejecuta : EditarCentroCostosModel, IRequest
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

                try {
                    var entidad = await _context.cntCentroCostos.FindAsync(request.Id);
    
                    if (entidad == null)
                    {
                        throw new Exception("Centro de Costo no encontrado");
                    };
    
                    var entidadDto = _mapper.Map<EditarCentroCostosModel, CntCentroCosto>(request,entidad);
                    var resultado = await _context.SaveChangesAsync();
                    if (resultado > 0)
                    {
                        return Unit.Value;
                    }
    
                    throw new Exception("No se realizaron modificaciones en la base de datos");
                } catch (Exception ex) {
                    //TODO: MARIA  Llave duplicada  CODIGO Centro Costo Implementar

                    throw new Exception("Error al editar registro catch " + ex.Message);
                }

            }
        }

    }



}