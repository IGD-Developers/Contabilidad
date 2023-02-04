using MediatR;
using System;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;
using AutoMapper;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.LiquidaImpuestos;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Entidades;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Entidades;

public class Insertar
{

    public class Ejecuta : InsertarEntidadModel, IRequest
    { }


    public class EjecutaValidador : AbstractValidator<Ejecuta>
    {
        public EjecutaValidador()
        {
            RuleFor(x => x.IdTercero).NotEmpty();
            RuleFor(x => x.IdTipoimpuesto).NotEmpty();

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



            var entidadDto = _mapper.Map<InsertarEntidadModel, CntEntidad>(request);


            _context.cntEntidades.Add(entidadDto);
            try
            {
                var respuesta = await _context.SaveChangesAsync();
                if (respuesta > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al insertar Entidad");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Insertar registro catch " + ex.Message);


            }
        }
    }
}