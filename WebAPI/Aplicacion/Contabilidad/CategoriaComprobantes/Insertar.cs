using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.CategoriaComprobantes;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using FluentValidation;
using MediatR;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.CategoriaComprobantes;

public class Insertar
{
    public class Ejecuta : InsertarCategoriaComprobantesModel, IRequest
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

            var entidadDto = _mapper.Map<InsertarCategoriaComprobantesModel, CntCategoriaComprobante>(request);

            //TODO: MARIA Llave duplicada Codigo 
            try
            {
                _context.cntCategoriaComprobantes.Add(entidadDto);
                var estado = await _context.SaveChangesAsync();
                if (estado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al insertar registro");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Insertar registro catch " + ex.Message);

            }
        }
    }


}