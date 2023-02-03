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
    public class Editar
    {
        public class Ejecuta : EditarTerceroModel, IRequest{}

         public class EjecutaValidador : AbstractValidator<Ejecuta>
        {
            public EjecutaValidador()
            {
                RuleFor(x=>x.id_tipodocumento).NotEmpty();
                RuleFor(x=>x.ter_documento).NotEmpty();
                /* RuleFor(x=>x.id_usuario).NotEmpty(); */
                RuleFor(x=>x.id_tippersona).NotEmpty();
                RuleFor(x=>x.id_genero).NotEmpty();
                RuleFor(x=>x.id_municipio).NotEmpty();
                RuleFor(x => x.ter_priapellido).NotEmpty();
                RuleFor(x => x.ter_prinombre).NotEmpty();
            }
        }

        public class Manejador : Funciones, IRequestHandler<Ejecuta>
        {
            private readonly CntContext _context;
            private readonly IMapper _mapper;
            private readonly IFunciones _funciones;

            public Manejador(CntContext context, IMapper mapper, IFunciones funciones)
            {
                _context = context;
                _mapper = mapper;
                _funciones = funciones;
                
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var tercero = await _context.CntTerceros.FindAsync(request.Id);               
                if(tercero == null){
                    throw new Exception("No se encontro tercero");
                } 

                var tipoPersona = await _context.CntTipoPersonas.Where(p => p.Codigo == "N")
                    .SingleOrDefaultAsync();                
                if(tipoPersona == null){
                    throw new Exception("No se encontro tipo persona");
                } 

                var responsabilidades = _context.cntResponsabilidadTerceros
                    .Where(z => z.IdTercero == request.Id)
                    .ToList();

                
                var segundoApellido = request.ter_segapellido.Trim() ?? "";
                var segundoNombre = request.ter_segnombre.Trim() ?? "";                
                request.ter_razonsocial = request.ter_priapellido.Trim() + " " + segundoApellido + " " + request.ter_prinombre.Trim() + " " + segundoNombre.Trim();
                
                request.ter_digitoverificacion = _funciones.CalcularDigitoVerificacion(tercero.TerDocumento);
                
                request.id_tippersona = tipoPersona.Id;
                request.id_genero = request.id_genero ?? tercero.IdGenero;
                request.id_tipodocumento = request.id_tipodocumento ?? tercero.IdTipodocumento;
                request.id_municipio = request.id_municipio ?? tercero.IdMunicipio;
                request.id_regimen = request.id_regimen ?? tercero.IdRegimen;
                request.id_ciiu = request.id_ciiu ?? tercero.IdCiiu;
                //request.id_usuario = request.id_usuario;
                request.ter_documento = request.ter_documento ?? tercero.TerDocumento;
                request.ter_prinombre = request.ter_prinombre ?? tercero.TerPrinombre;               
                request.ter_priapellido = request.ter_priapellido ?? tercero.TerPriapellido;
                               

                var transaction = _context.Database.BeginTransaction();
                try {

                    var entidadDto = _mapper.Map<EditarTerceroModel, CntTercero>(request, tercero);
                    
                    _context.RemoveRange(responsabilidades);
                    if(request.responsabilidadTerceroModel != null){
                       
                        var idResponsabilidades = (from num in request.responsabilidadTerceroModel select num.id_responsabilidad).Distinct().ToList();

                        EditarResponsabilidadTerceroModel registro = new EditarResponsabilidadTerceroModel();

                        // Agregar los registros que vienen del request 
                        foreach (int idResponsabilidad in idResponsabilidades)
                        {
                            registro.id_responsabilidad = idResponsabilidad;
                            registro.IdTercero = request.Id;    

                            var responsabilidad = await _context.cntResponsabilidades.FindAsync(registro.id_responsabilidad);
                            if(responsabilidad == null){
                                throw new Exception("No se encontro Responsabilidad, error al insertar ResponsabilidadTercero");
                            }                            
                            
                            var detalleDto = _mapper.Map<EditarResponsabilidadTerceroModel, CntResponsabilidadTer>(registro);

                            _context.cntResponsabilidadTerceros.Add(detalleDto);

                        }
                        var respuesta2 = await _context.SaveChangesAsync();
                        if (respuesta2 > 0)
                        {

                            transaction.Commit();
                            return Unit.Value;

                        }
                    } 
                    

                    //var resultado = await _context.SaveChangesAsync();
                   
                    //TODO: VALIDACION DE MSJ ERROR
                    throw new Exception("No se realizaron modificaciones el tercero");
                } catch (Exception ex) {

                    throw new Exception("Error al Editar tercero catch " + ex.Message);
                }
            }
        }

    }
}