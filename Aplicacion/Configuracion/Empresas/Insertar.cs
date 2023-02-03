using MediatR;
using Persistencia;
using Dominio.Configuracion;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;
using Aplicacion.Models.Configuracion.Empresas;
using AutoMapper;
using System;
using MySqlConnector;

namespace Aplicacion.Configuracion.Empresas
{
    public class Insertar
    {

        public class Ejecuta : InsertarEmpresasModel, IRequest
        { }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.nit).NotEmpty();
                RuleFor(x => x.razon_social).NotEmpty();
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

                //Como vamos a grabar primero el modelo y luego la entidad:
                var empresaDto = _mapper.Map<InsertarEmpresasModel, CnfEmpresa>(request);


                //El mapeo va asi en el mappingprofile: CreateMap<InsertarEmpresasModel,CnfEmpresa>();

                try
                {
                    await _context.cnfEmpresas.AddAsync(empresaDto);
                    var respuesta = await _context.SaveChangesAsync();
                    if (respuesta > 0)
                    {
                        return Unit.Value;
                    }
                    throw new System.Exception("No se ha realizado modificaciones a la base de datos");
                }
                catch (Exception ex)
                {

                    //TODO Maria: LLave duplicada implementar validacion
                    var sqlException = ex.InnerException;
                    System.Console.WriteLine(sqlException);

                    if (ex.GetBaseException().GetType() == typeof(MySqlException))
                    {

                        var sqlException1 = ex.InnerException as MySqlException;
                        if (sqlException1.Number == 1062)
                        {
                            System.Console.WriteLine("***************Llave duplicada *****************");

                        }

                    }
                    //System.Console.WriteLine("***************Error de Grabación - Servidor No Disponible *****************");
                    throw new Exception("Error al Insertar registro catch " + ex.Message);
                }


            }
        }
    }
}



