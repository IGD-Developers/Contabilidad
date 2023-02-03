using Persistencia;
using System;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;
using Aplicacion.Models.Contabilidad.Bancos;
using AutoMapper;
using Dominio.Contabilidad;

namespace Aplicacion.Contabilidad.Bancos
{
    public class Editar
    {
        public class Ejecuta : EditarBancosModel, IRequest
        { }


        public class EjecutaValidador : AbstractValidator<Ejecuta>
        {
            public EjecutaValidador()
            {
                //RuleFor(x => x.Id).NotEmpty();
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


                try
                {
                    var banco = await _context.cntBancos.FindAsync(request.Id);
                    if (banco == null)
                    {
                        throw new Exception("Banco no encontrado");
                    };

                    //Como vamos a grabar primero el modelo y luego la entidad:
                    var entidadDto = _mapper.Map<EditarBancosModel, CntBanco>(request, banco);

                    //El mapeo va asi en el mappingprofile: CreateMap<EditarEntidadModel,Entidad>();

                    var resultado = await _context.SaveChangesAsync();
                    if (resultado > 0)
                    {
                        return Unit.Value;
                    }
                    throw new Exception("No se realizaron modificaciones al registro");
                }
                catch (Exception ex)
                {
                    //TODO: MARIA Llave duplicada  CODIGO BANCO Implementar

                    throw new Exception("Error al editar registro catch " + ex.Message);
                }

            }
        }




    }
}