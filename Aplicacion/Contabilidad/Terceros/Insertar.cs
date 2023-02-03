using System;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.Models.Contabilidad.ResponsabilidadTercero;
using Aplicacion.Models.Contabilidad.Tercero;
using AutoMapper;
using Dominio.Contabilidad;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Contabilidad.Terceros
{
    public class Insertar
    {
        public class Ejecuta : InsertarTerceroModel, IRequest
        {

        }

        public class EjecutaValidador : AbstractValidator<Ejecuta>
        {
            public EjecutaValidador()
            {
                RuleFor(x => x.id_tipodocumento).NotEmpty();
                RuleFor(x => x.ter_documento).NotEmpty();
                RuleFor(x => x.id_usuario).NotEmpty();
                RuleFor(x => x.id_tippersona).NotEmpty();
                RuleFor(x => x.id_genero).NotEmpty();
                RuleFor(x => x.id_municipio).NotEmpty();
                RuleFor(x => x.ter_priapellido).NotEmpty();
                RuleFor(x => x.ter_prinombre).NotEmpty();
                RuleFor(x => x.responsabilidadTerceroModel).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            public readonly CntContext _context;
            private readonly IMapper _mapper;
            private readonly IFunciones _funciones;


            public Manejador(CntContext context, IMapper mapper, IFunciones funciones)
            {
                _context = context;
                _mapper = mapper;
                _funciones = funciones;
            }

            //List<int> distinct = list.Distinct().ToList();     

            
            //TODO:AGGD - VALLIDAR QUE NO RECIBIR EL MISMO ID RESPONSABILIDAD VARIAS VECES
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var segundoApellido = request.ter_segapellido.Trim() ?? "";
                var segundoNombre = request.ter_segnombre.Trim() ?? "";
                request.ter_digitoverificacion = _funciones.CalcularDigitoVerificacion(request.ter_documento);
                request.ter_razonsocial = request.ter_priapellido.Trim() + " " + segundoApellido + " " + request.ter_prinombre.Trim() + " " + segundoNombre.Trim();

                var transaction = _context.Database.BeginTransaction();
                try
                {
                    var terceroDto = _mapper.Map<InsertarTerceroModel, CntTercero>(request);
                    await _context.CntTerceros.AddAsync(terceroDto);
                    var valor = await _context.SaveChangesAsync();
                    var idTercero = terceroDto.id;
                    
                    if(request.responsabilidadTerceroModel == null){
                        //TODO:AGGD - VALIDAR QUE ENVIE MINIMO NO RESPONSABLE
                    }


                    if (request.responsabilidadTerceroModel != null)
                    {

                        var idResponsabilidades = (from num in request.responsabilidadTerceroModel select num.id_responsabilidad).Distinct().ToList();

                        InsertarResponsabilidadTerceroModel registro = new InsertarResponsabilidadTerceroModel();

                        // Agregar los registros que vienen del request 
                        //foreach (InsertarResponsabilidadTerceroModel registro in request.responsabilidadTerceroModel)
                        foreach (int idResponsabilidad in idResponsabilidades)
                        {
                            registro.id_responsabilidad = idResponsabilidad;
                            registro.id_tercero = idTercero;

                            var responsabilidad = await _context.cntResponsabilidades.FindAsync(registro.id_responsabilidad);
                            if (responsabilidad == null)
                            {
                                throw new Exception("No se encontro Responsabilidad, error al insertar ResponsabilidadTercero");
                            }

                            var detalleDto = _mapper.Map<InsertarResponsabilidadTerceroModel, CntResponsabilidadTer>(registro);

                            _context.cntResponsabilidadTerceros.Add(detalleDto);

                        }
                        var respuesta2 = await _context.SaveChangesAsync();
                        if (respuesta2 > 0)
                        {

                            transaction.Commit();
                            return Unit.Value;

                        }
                    }

                    throw new Exception("No se pudo insertar el Tercero");
                }
                catch (SystemException e)
                {
                    throw new Exception("Error inesperado al insertar el Tercero" + e);
                }

            }

        }
    }
}