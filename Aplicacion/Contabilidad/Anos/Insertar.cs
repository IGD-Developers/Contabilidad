using Persistencia;
using Dominio.Contabilidad;
using MediatR;
using System;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;
using Aplicacion.Models.Contabilidad.Anos;
using AutoMapper;
using MySqlConnector;

namespace Aplicacion.Contabilidad.Anos;

public class Insertar
{
    public class Ejecuta: InsertarAnoModel, IRequest
    {



    }

    public class EjecutaValidador : AbstractValidator<Ejecuta>
    {
        public EjecutaValidador()
        {
            RuleFor(x=>x.id_comprobante).NotEmpty();
            RuleFor(x=>x.ano_ano).NotEmpty();
            RuleFor(x=>x.ano_cerrado).NotEmpty();
            RuleFor(x=>x.estado).NotEmpty();
            RuleFor(x=>x.id_usuario).NotEmpty();
        }
    }

    public class Manejador: IRequestHandler<Ejecuta>
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
            var entidadDto = _mapper.Map<InsertarAnoModel, CntAno>(request);


                try {
                    _context.cntAnos.Add(entidadDto);
                    var respuesta = await _context.SaveChangesAsync();
                    if (respuesta > 0)
                    {
                        return Unit.Value;
                    }
                    throw new System.Exception("No se ha realizado modificaciones a la base de datos");
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

            // var ano = new CntAno
            // {
            //     id_comprobante = request.id_comprobante,
            //     ano_ano = request.ano_ano,
            //     ano_cerrado = request.ano_cerrado,
            //     ano_estado = request.ano_estado,
            //     id_usuario = request.id_usuario

            // };

            // try {
            //     _context.cntAnos.Add(ano);
            //     var respuesta = await _context.SaveChangesAsync();
            //     if( respuesta>0)
            //     {
            //         return Unit.Value;

            //     }
            //     throw new Exception("Error al insertar año");

            // } catch (SystemException) {

            //      throw new Exception("Error Inesperado al insertar año");

            // }

        }
    }
    
}