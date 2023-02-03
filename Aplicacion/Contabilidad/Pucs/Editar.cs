using Persistencia;
using System;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;
using Dominio.Contabilidad;
using Aplicacion.Models.Contabilidad.Pucs;
using AutoMapper;

namespace Aplicacion.Contabilidad.Pucs
{
    public class Editar
    {

        public class Ejecuta : EditarPucModel, IRequest
        { }


        public class EjecutaValidador : AbstractValidator<Ejecuta>
        {
            public EjecutaValidador()
            {
                
                RuleFor(x => x.nombre).NotEmpty();
                RuleFor(x => x.id_puctipo).NotEmpty();
                RuleFor(x => x.id_tipocuenta).NotEmpty();
                RuleFor(x=>x.pac_activa).Must(x => x == false || x == true);
                RuleFor(x=>x.pac_base).Must(x => x == false || x == true);
                RuleFor(x=>x.pac_ajusteniif).Must(x => x == false || x == true);


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
                // puc.nombre = request.nombre;
                // puc.id_puctipo= request.id_puctipo;
                // puc.id_tipocuenta = request.id_tipocuenta;
                // puc.codigo = request.codigo;
                // puc.pac_activa =request.pac_activa;
                // puc.pac_base =request.pac_base;
                // puc.pac_ajusteniif = request.pac_ajusteniif;
                // puc.id_usuario = request.id_usuario;
}