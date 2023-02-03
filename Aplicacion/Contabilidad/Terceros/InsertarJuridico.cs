using System;
using System.Linq;
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

namespace Aplicacion.Contabilidad.Terceros;

public class InsertarJuridico
{
    public class Ejecuta : InsertarJuridicoModel, IRequest{}

    public class EjecutaValidador : AbstractValidator<Ejecuta>
    {
        public EjecutaValidador()
        {
            RuleFor(x => x.id_tipodocumento).NotEmpty();
            RuleFor(x => x.ter_documento).NotEmpty();
            RuleFor(x => x.id_usuario).NotEmpty();
            RuleFor(x => x.id_tippersona).NotEmpty();
            RuleFor(x => x.id_municipio).NotEmpty();
            RuleFor(x => x.id_regimen).NotEmpty();
            RuleFor(x => x.id_regimen).NotEmpty();
            RuleFor(x => x.ter_razonsocial).NotEmpty();
            RuleFor(x => x.responsabilidadTerceroJuridicoModel).NotEmpty();
        }
    }

    public class Manejador : Funciones, IRequestHandler<Ejecuta>
    {
        private readonly CntContext _context;
        private readonly IMapper _mapper;
        private readonly IFunciones _funciones;
    

        public Manejador(CntContext context, IMapper mapper , IFunciones funciones)
        {
            _context = context;
            _mapper = mapper;
            _funciones = funciones;
        }

        public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
        {
           var genero = await _context.CntGeneros.Where(p => p.codigo == "NA")
                .SingleOrDefaultAsync();
            if(genero == null){
                throw new Exception("No se encontro genero");
            }

            var tipoPersona = await _context.CntTipoPersonas.Where(p => p.codigo == "J")
                .SingleOrDefaultAsync();

            if(tipoPersona == null){
                throw new Exception("No se encontro tipo persona");
            }

            request.ter_digitoverificacion =  _funciones.CalcularDigitoVerificacion(request.ter_documento);
           
            var transaction = _context.Database.BeginTransaction();
            try
            {
                var entidadDto = _mapper.Map<InsertarJuridicoModel, CntTercero>(request);
                await _context.CntTerceros.AddAsync(entidadDto);
                var valor = await _context.SaveChangesAsync();
                var idTercero = entidadDto.id;

                if(request.responsabilidadTerceroJuridicoModel != null){
                   
                    var idResponsabilidades = (from num in request.responsabilidadTerceroJuridicoModel select num.id_responsabilidad).Distinct().ToList();

                    InsertarResponsabilidadTerceroModel registro = new InsertarResponsabilidadTerceroModel();

                    // Agregar los registros que vienen del request 
                    foreach (int idResponsabilidad in idResponsabilidades)
                    {
                        registro.id_responsabilidad = idResponsabilidad;
                        registro.id_tercero = idTercero;
                        
                        var responsabilidad = await _context.cntResponsabilidades.FindAsync(registro.id_responsabilidad);
                        if(responsabilidad == null){
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