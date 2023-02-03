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

public class EditarJuridico
{
    public class Ejecuta : EditarJuridicoModel, IRequest{}

    public class EjecutaValidador : AbstractValidator<Ejecuta>
    {
        public EjecutaValidador()
            {
                RuleFor(x => x.IdTipodocumento).NotEmpty();
                RuleFor(x => x.TerDocumento).NotEmpty();
                /* RuleFor(x => x.IdUsuario).NotEmpty(); */
                RuleFor(x => x.IdTippersona).NotEmpty();
                RuleFor(x => x.IdMunicipio).NotEmpty();
                RuleFor(x => x.IdRegimen).NotEmpty();
                RuleFor(x => x.IdRegimen).NotEmpty();
                RuleFor(x => x.TerRazonsocial).NotEmpty();
                //RuleFor(x => x.IdGenero).Matches("^[A,U,M]+");
                //RuleFor(x=>x.PacBase).Must(x => x == false || x == true);
                RuleFor(x => x.ResponsabilidadTerceroJuridicoModel).NotEmpty();
              
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

            var Tercero = await _context.CntTerceros.FindAsync(request.Id);
            if(Tercero == null){
                throw new Exception("No se encontro Tercero");
            }   
            
            var tipoPersona = await _context.CntTipoPersonas.Where(p => p.Codigo == "J")
                .SingleOrDefaultAsync();
            if(tipoPersona == null){
                throw new Exception("No se encontro tipo persona");
            }

            var genero = await _context.CntGeneros.Where(p => p.Codigo == "NA")
                .SingleOrDefaultAsync();                   
            if(genero == null){
                throw new Exception("No se encontro genero");
            }
            
            request.IdTippersona = tipoPersona.Id;
            request.IdGenero = genero.Id;
            request.TerDigitoverificacion = _funciones.CalcularDigitoVerificacion(Tercero.TerDocumento);
            request.IdTipodocumento = request.IdTipodocumento ?? Tercero.IdTipodocumento;
            request.IdMunicipio = request.IdMunicipio ?? Tercero.IdMunicipio;
            request.IdRegimen = request.IdRegimen ?? Tercero.IdRegimen;
            request.IdCiiu = request.IdCiiu ?? Tercero.IdCiiu;
            //request.IdUsuario = request.IdUsuario;
            request.TerDocumento = request.TerDocumento ?? Tercero.TerDocumento;
            request.TerRazonsocial = request.TerRazonsocial ?? Tercero.TerRazonsocial;
                            
            var responsabilidades = _context.cntResponsabilidadTerceros
                .Where(z => z.IdTercero == request.Id)
                .ToList();                              
            
                
                var transaction = _context.Database.BeginTransaction();
            try {

                var entidadDto = _mapper.Map<EditarJuridicoModel, CntTercero>(request, Tercero);
                                    
                _context.RemoveRange(responsabilidades);

                if(request.ResponsabilidadTerceroJuridicoModel != null){
                    
                   var idResponsabilidades = (from num in request.ResponsabilidadTerceroJuridicoModel select num.IdResponsabilidad).Distinct().ToList();

                    EditarResponsabilidadTerceroJuridicoModel registro = new EditarResponsabilidadTerceroJuridicoModel();

                    // Agregar los registros que vienen del request 
                    foreach (int idResponsabilidad in idResponsabilidades)
                    {
                        registro.IdResponsabilidad = idResponsabilidad;
                        registro.IdTercero = request.Id;                       
                        
                        var responsabilidad = await _context.cntResponsabilidades.FindAsync(registro.IdResponsabilidad);
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

        
                throw new Exception("No se modificó el Tercero juridico");

            } catch (SystemException e) {

                throw new Exception("Error inesperado al insertar el Tercero juridico" + e);
            }
        }
    }

}