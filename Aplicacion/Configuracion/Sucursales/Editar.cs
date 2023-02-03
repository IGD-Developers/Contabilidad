using MediatR;
using Persistencia;
using Dominio.Configuracion;
using System.Threading.Tasks;
using System.Threading;
using System;
using FluentValidation;
using Aplicacion.Models.Configuracion.Sucursales;
using AutoMapper;

namespace Aplicacion.Configuracion.Sucursales;

public class Editar
{

    public class Ejecuta : EditarSucursalModel, IRequest
    {

    }


    public class EjecutaValidador : AbstractValidator<Ejecuta>
    {
        public EjecutaValidador()
        {
           //RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Codigo).NotEmpty();
            RuleFor(x => x.Nombre).NotEmpty();
            RuleFor(x => x.IdEmpresa).NotEmpty();

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
                var consulta = await _context.cnfEmpresas.FindAsync(request.IdEmpresa);
                    if (consulta == null)
                    {
                        throw new Exception("Empresa no encontrada");
                    };

                try
                {
                    

                    var consultaDb = await _context.cnfSucursales.FindAsync(request.Id);
                    if (consultaDb == null)
                    {
                        throw new Exception("Sucursal no encontrada");
                    };


                    //Como vamos a grabar primero el modelo y luego la entidad:
                    var empresasDto = _mapper.Map<EditarSucursalModel, CnfSucursal>(request, consultaDb);

                    //El mapeo va asi en el mappingprofile: CreateMap<EditarSucursalModel,CnfSucursal>();


                    var resultado = await _context.SaveChangesAsync();
                    if (resultado > 0)
                    {
                        return Unit.Value;
                    }
                    //Ojo 00 Vista con mensaje

                    throw new Exception("No se realizaron modificaciones al registro");

                }
                catch (Exception ex)
                {
                    throw new Exception("Error al editar registro catch " + ex.Message);
                }

            }
        }
    }

}