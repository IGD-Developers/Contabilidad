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

namespace Aplicacion.Contabilidad.Terceros
{
    public class EditarJuridico
    {
        public class Ejecuta : EditarJuridicoModel, IRequest{}

        public class EjecutaValidador : AbstractValidator<Ejecuta>
        {
            public EjecutaValidador()
                {
                    RuleFor(x => x.id_tipodocumento).NotEmpty();
                    RuleFor(x => x.ter_documento).NotEmpty();
                    /* RuleFor(x => x.id_usuario).NotEmpty(); */
                    RuleFor(x => x.id_tippersona).NotEmpty();
                    RuleFor(x => x.id_municipio).NotEmpty();
                    RuleFor(x => x.id_regimen).NotEmpty();
                    RuleFor(x => x.id_regimen).NotEmpty();
                    RuleFor(x => x.ter_razonsocial).NotEmpty();
                    //RuleFor(x => x.id_genero).Matches("^[A,U,M]+");
                    //RuleFor(x=>x.pac_base).Must(x => x == false || x == true);
                    RuleFor(x => x.responsabilidadTerceroJuridicoModel).NotEmpty();
                  
                }
        }
        public class Manejador :Funciones, IRequestHandler<Ejecuta>
        {
            private readonly CntContext _context;
            private readonly IMapper _mapper;
            private readonly IFunciones _funciones;

            public Manejador(CntContext context, IMapper mapper, IFunciones funciones)
            {
                _funciones = funciones;
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {

                var tercero = await _context.CntTerceros.FindAsync(request.Id);
                if(tercero == null){
                    throw new Exception("No se encontro tercero");
                }   
                
                var tipoPersona = await _context.CntTipoPersonas.Where(p => p.codigo == "J")
                    .SingleOrDefaultAsync();
                if(tipoPersona == null){
                    throw new Exception("No se encontro tipo persona");
                }

                var genero = await _context.CntGeneros.Where(p => p.codigo == "NA")
                    .SingleOrDefaultAsync();                   
                if(genero == null){
                    throw new Exception("No se encontro genero");
                }
                
                request.id_tippersona = tipoPersona.id;
                request.id_genero = genero.id;
                request.ter_digitoverificacion = _funciones.CalcularDigitoVerificacion(tercero.ter_documento);
                request.id_tipodocumento = request.id_tipodocumento ?? tercero.id_tipodocumento;
                request.id_municipio = request.id_municipio ?? tercero.id_municipio;
                request.id_regimen = request.id_regimen ?? tercero.id_regimen;
                request.id_ciiu = request.id_ciiu ?? tercero.id_ciiu;
                //request.id_usuario = request.id_usuario;
                request.ter_documento = request.ter_documento ?? tercero.ter_documento;
                request.ter_razonsocial = request.ter_razonsocial ?? tercero.ter_razonsocial;
                                
                var responsabilidades = _context.cntResponsabilidadTerceros
                    .Where(z => z.id_tercero == request.Id)
                    .ToList();                              
                
                    
                    var transaction = _context.Database.BeginTransaction();
                try {

                    var entidadDto = _mapper.Map<EditarJuridicoModel, CntTercero>(request, tercero);
                                        
                    _context.RemoveRange(responsabilidades);

                    if(request.responsabilidadTerceroJuridicoModel != null){
                        
                       var idResponsabilidades = (from num in request.responsabilidadTerceroJuridicoModel select num.id_responsabilidad).Distinct().ToList();

                        EditarResponsabilidadTerceroJuridicoModel registro = new EditarResponsabilidadTerceroJuridicoModel();

                        // Agregar los registros que vienen del request 
                        foreach (int idResponsabilidad in idResponsabilidades)
                        {
                            registro.id_responsabilidad = idResponsabilidad;
                            registro.id_tercero = request.Id;                       
                            
                            var responsabilidad = await _context.cntResponsabilidades.FindAsync(registro.id_responsabilidad);
                            if(responsabilidad == null){
                                throw new Exception("No se encontro Responsabilidad, error al insertar ResponsabilidadTercero");
                            }
                            
                            var detalleDto = _mapper.Map<EditarResponsabilidadTerceroJuridicoModel, CntResponsabilidadTer>(registro);

                            _context.cntResponsabilidadTerceros.Add(detalleDto);

                        }
                        var respuesta2 = await _context.SaveChangesAsync();
                        if (respuesta2 > 0)
                        {
                            transaction.Commit();
                            return Unit.Value;
                        }
                    } 

            
                    throw new Exception("No se modificó el tercero juridico");

                } catch (SystemException e) {

                    throw new Exception("Error inesperado al insertar el Tercero juridico" + e);
                }
            }
        }

    }
}