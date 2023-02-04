using MediatR;
using System;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;
using AutoMapper;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.CategoriaComprobantes;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.CategoriaComprobantes;

public class Editar
{

    public class Ejecuta : EditarCategoriaComprobantesModel, IRequest
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
        private readonly CntContext _context;
        private readonly IMapper _mapper;

        public Manejador(CntContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
        {

            {

                try
                {
                    var entidad = await _context.cntCategoriaComprobantes.FindAsync(request.Id);

                    if (entidad == null)
                    {
                        throw new Exception("Categoría no encontrada");
                    };

                    var entidadDto = _mapper.Map<EditarCategoriaComprobantesModel, CntCategoriaComprobante>(request, entidad);

                    var resultado = await _context.SaveChangesAsync();
                    if (resultado > 0)
                    {
                        return Unit.Value;
                    }

                    throw new Exception("No se realizaron cambios en la base de datos");
                }
                catch (Exception ex)
                {
                    //TODO: MARIA  Llave duplicada  CODIGO BANCO Implementar

                    throw new Exception("Error al editar registro catch " + ex.Message);

                }
            }
        }
    }
}