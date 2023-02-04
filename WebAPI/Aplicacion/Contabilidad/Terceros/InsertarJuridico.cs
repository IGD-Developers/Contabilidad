using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.ResponsabilidadTercero;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Tercero;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Terceros;

public class InsertarJuridico
{
    public class Ejecuta : InsertarJuridicoModel, IRequest { }

    public class EjecutaValidador : AbstractValidator<Ejecuta>
    {
        public EjecutaValidador()
        {
            RuleFor(x => x.IdTipodocumento).NotEmpty();
            RuleFor(x => x.TerDocumento).NotEmpty();
            RuleFor(x => x.IdUsuario).NotEmpty();
            RuleFor(x => x.IdTippersona).NotEmpty();
            RuleFor(x => x.IdMunicipio).NotEmpty();
            RuleFor(x => x.IdRegimen).NotEmpty();
            RuleFor(x => x.IdRegimen).NotEmpty();
            RuleFor(x => x.TerRazonsocial).NotEmpty();
            RuleFor(x => x.ResponsabilidadTerceroJuridicoModel).NotEmpty();
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
            var genero = await _context.CntGeneros.Where(p => p.Codigo == "NA")
                 .SingleOrDefaultAsync();
            if (genero == null)
            {
                throw new Exception("No se encontro genero");
            }

            var tipoPersona = await _context.CntTipoPersonas.Where(p => p.Codigo == "J")
                .SingleOrDefaultAsync();

            if (tipoPersona == null)
            {
                throw new Exception("No se encontro tipo persona");
            }

            request.TerDigitoverificacion = _funciones.CalcularDigitoVerificacion(request.TerDocumento);

            var transaction = _context.Database.BeginTransaction();
            try
            {
                var entidadDto = _mapper.Map<InsertarJuridicoModel, CntTercero>(request);
                await _context.CntTerceros.AddAsync(entidadDto);
                var valor = await _context.SaveChangesAsync();
                var idTercero = entidadDto.Id;

                if (request.ResponsabilidadTerceroJuridicoModel != null)
                {

                    var idResponsabilidades = (from num in request.ResponsabilidadTerceroJuridicoModel select num.IdResponsabilidad).Distinct().ToList();

                    InsertarResponsabilidadTerceroModel registro = new InsertarResponsabilidadTerceroModel();

                    // Agregar los registros que vienen del request 
                    foreach (int idResponsabilidad in idResponsabilidades)
                    {
                        registro.IdResponsabilidad = idResponsabilidad;
                        registro.IdTercero = idTercero;

                        var responsabilidad = await _context.cntResponsabilidades.FindAsync(registro.IdResponsabilidad);
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