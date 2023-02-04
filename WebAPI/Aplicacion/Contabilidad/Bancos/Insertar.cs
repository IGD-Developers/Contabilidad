using System;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;
using AutoMapper;
using MySqlConnector;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Bancos;
using ContabilidadWebAPI.Persistencia;
using ContabilidadWebAPI.Dominio.Contabilidad;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Bancos;

public class Insertar

{

    public class Ejecuta : InsertarBancosModel, IRequest
    {

    }

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
            var entidadDto = _mapper.Map<InsertarBancosModel, CntBanco>(request);

            try
            {
                await _context.cntBancos.AddAsync(entidadDto);
                var respuesta = await _context.SaveChangesAsync();
                if (respuesta > 0)
                {

                    return Unit.Value;
                }
                throw new Exception("Error al insertar banco");
            }
            catch (Exception ex)
            {
                //TODO: MARIA  Llave duplicada  CODIGO BANCO Implementar

                var sqlException = ex.InnerException;
                Console.WriteLine(sqlException);

                if (ex.GetBaseException().GetType() == typeof(MySqlException))
                {

                    var sqlException1 = ex.InnerException as MySqlException;
                    if (sqlException1.Number == 1062)
                    {
                        Console.WriteLine("***************Llave duplicada *****************");

                    }

                }
                //System.Console.WriteLine("***************Error de Grabación - Servidor No Disponible *****************");
                throw new Exception("Error al Insertar registro catch " + ex.Message);




                // var banco = new CntBanco 
                // {
                //     Codigo =request.Codigo,
                //     Nombre=request.Nombre
                // };
                // _context.cntBancos.Add(banco);
                // var respuesta= await _context.SaveChangesAsync();



                throw new Exception("Error al insertar banco");
            }
        }


    }
}