using MediatR;
using Persistencia;
using Dominio.Configuracion;
using System.Threading.Tasks;
using System.Threading;
using System;
using FluentValidation;
using Aplicacion.Models.Configuracion.Sucursales;
using AutoMapper;
using MySqlConnector;

namespace Aplicacion.Configuracion.Sucursales
{
    public class Insertar
    {
        public class Ejecuta : InsertarSucursalModel, IRequest
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
            private readonly CntContext context;
            private readonly IMapper _mapper;



            public Manejador(CntContext context, IMapper mapper)
            {
                this.context = context;
                _mapper = mapper;

            }


            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {

                //Como vamos a grabar primero el modelo y luego la entidad:
                var entidadDto = _mapper.Map<InsertarSucursalModel, CnfSucursal>(request);

                //El mapeo va asi en el mappingprofile: CreateMap<InsertarEntidadModel,CnfEmpresa>();


                try
                {
                    await context.cnfSucursales.AddAsync(entidadDto);
                    var respuesta = await context.SaveChangesAsync();
                    if (respuesta > 0)
                    {

                        return Unit.Value;
                    }

                    throw new Exception("Error  al insertar Empresa");
                }
                catch (Exception ex)
                {
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

                // var Sucursal = new CnfSucursal()
                // {
                //     Codigo = request.Codigo,
                //     Nombre = request.Nombre,
                //     id_empresa = request.id_empresa
                // };

            }
        }

    }
}