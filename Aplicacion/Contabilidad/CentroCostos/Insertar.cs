using Persistencia;
using Dominio.Contabilidad;
using MediatR;
using System;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;
using AutoMapper;
using Aplicacion.Models.Contabilidad.CentroCostos;

namespace Aplicacion.Contabilidad.CentroCostos;

public class Insertar
{

    public class Ejecuta : InsertarCentroCostosModel, IRequest
    { }

    public class Manejador : IRequestHandler<Ejecuta>
    {
        private CntContext _context;
        private readonly IMapper _mapper;



        public Manejador(CntContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public class EjecutaValidador : AbstractValidator<Ejecuta>
        {
            public EjecutaValidador()
            {
                RuleFor(x => x.Codigo).NotEmpty();
                RuleFor(x => x.Nombre).NotEmpty();

            }
        }

        public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
        {

            var entidadDto = _mapper.Map<InsertarCentroCostosModel, CntCentroCosto>(request);


            try
            {
                _context.cntCentroCostos.Add(entidadDto);

                var respuesta = await _context.SaveChangesAsync();
                if (respuesta > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al insertar CentroCosto");
                //TODO: MARIA  Llave duplicada  CODIGO CentroCosto Implementar
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Insertar registro catch " + ex.Message);

            }
        }
    }

}