using Persistencia;
using System;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;
using Aplicacion.Models.Contabilidad.Entidades;
using Dominio.Contabilidad;
using AutoMapper;

namespace Aplicacion.Contabilidad.Entidades;

public class Editar
{


    public class Ejecuta : EditarEntidadModel, IRequest
    {


    }
    public class EjecutaValidador : AbstractValidator<Ejecuta>
    {
        public EjecutaValidador()
        {
            //RuleFor(x=>x.Id).NotEmpty();
            RuleFor(x => x.id_tercero).NotEmpty();
            RuleFor(x => x.id_tipoimpuesto).NotEmpty();

        }
    }

    public class Manejador : IRequestHandler<Ejecuta>
    {
        private readonly CntContext _context;
        private readonly IMapper _mapper;



        public Manejador(CntContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
        {

            var entidad = await _context.cntEntidades.FindAsync(request.Id);
            if (entidad == null)
            {
                throw new Exception("Registro no encontrado");
            };

            var endidadDto = _mapper.Map<EditarEntidadModel, CntEntidad>(request, entidad);

            try
            {
                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se realizaron modificaciones al registro");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar registro catch " + ex.Message);
            }

        }
    }
}