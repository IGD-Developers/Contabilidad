using MediatR;
using System;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;
using AutoMapper;
using ContabilidadWebAPI.Dominio.Configuracion;
using ContabilidadWebAPI.Persistencia;
using ContabilidadWebAPI.Aplicacion.Models.Configuracion.Empresas;

namespace ContabilidadWebAPI.Aplicacion.Configuracion.Empresas;

public class Editar
{
    public class Ejecuta : EditarEmpresasModel, IRequest
    {


    }

    public class EjecutaValidador : AbstractValidator<Ejecuta>
    {
        public EjecutaValidador()
        {
            RuleFor(x => x.Nit).NotEmpty();
            RuleFor(x => x.RazonSocial).NotEmpty();
            //RuleFor(x=>x.IdTerceroGerente).NotEmpty();

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
                var Empresa = await _context.cnfEmpresas.FindAsync(request.Id);
                if (Empresa == null)
                {
                    throw new Exception("Empresa no encontrada");
                };

                request.IdTerceroGerente ??= Empresa.IdTerceroGerente;

                //Como vamos a grabar primero el modelo y luego la entidad:
                var empresasDto = _mapper.Map<EditarEmpresasModel, CnfEmpresa>(request, Empresa);

                //El mapeo va asi en el mappingprofile: CreateMap<EditarEmpresasModel,CnfEmpresa>();


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

