using Persistencia;
using System;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;
using Dominio.Contabilidad;
using Aplicacion.Models.Contabilidad.Pucs;
using AutoMapper;

namespace Aplicacion.Contabilidad.Pucs;

public class Editar
{

    public class Ejecuta : EditarPucModel, IRequest
    { }


    public class EjecutaValidador : AbstractValidator<Ejecuta>
    {
        public EjecutaValidador()
        {
            
            RuleFor(x => x.Nombre).NotEmpty();
            RuleFor(x => x.IdPuctipo).NotEmpty();
            RuleFor(x => x.IdTipocuenta).NotEmpty();
            RuleFor(x=>x.PacActiva).Must(x => x == false || x == true);
            RuleFor(x=>x.PacBase).Must(x => x == false || x == true);
            RuleFor(x=>x.PacAjusteniif).Must(x => x == false || x == true);


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
            var entidad = await _context.cntPucs.FindAsync(request.Id);
            if (entidad == null)
            {
                throw new Exception("Registro no encontrado");
            };

            var entidadDto = _mapper.Map<EditarPucModel, CntPuc>(request, entidad);

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
                //TODO: MARIA  Llave duplicada  CODIGO PUC Implementar

                throw new Exception("Error al editar registro catch " + ex.Message);
            }

        }
    }
}
            // puc.Nombre = request.Nombre;
            // puc.IdPuctipo= request.IdPuctipo;
            // puc.IdTipocuenta = request.IdTipocuenta;
            // puc.Codigo = request.Codigo;
            // puc.PacActiva =request.PacActiva;
            // puc.PacBase =request.PacBase;
            // puc.PacAjusteniif = request.PacAjusteniif;
            // puc.IdUsuario = request.IdUsuario;