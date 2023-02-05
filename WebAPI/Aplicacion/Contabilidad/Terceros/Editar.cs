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

public class EditarTerceroRequest : EditarTerceroModel, IRequest { }

public class EditarTerceroValidator : AbstractValidator<EditarTerceroRequest>
{
    public EditarTerceroValidator()
    {
        RuleFor(x => x.IdTipodocumento).NotEmpty();
        RuleFor(x => x.TerDocumento).NotEmpty();
        /* RuleFor(x=>x.IdUsuario).NotEmpty(); */
        RuleFor(x => x.IdTippersona).NotEmpty();
        RuleFor(x => x.IdGenero).NotEmpty();
        RuleFor(x => x.IdMunicipio).NotEmpty();
        RuleFor(x => x.TerPriapellido).NotEmpty();
        RuleFor(x => x.TerPrinombre).NotEmpty();
    }
}

public class EditarTerceroHandler : Funciones, IRequestHandler<EditarTerceroRequest>
{
    private readonly CntContext _context;
    private readonly IMapper _mapper;
    private readonly IFunciones _funciones;

    public EditarTerceroHandler(CntContext context, IMapper mapper, IFunciones funciones)
    {
        _context = context;
        _mapper = mapper;
        _funciones = funciones;

    }

    public async Task<Unit> Handle(EditarTerceroRequest request, CancellationToken cancellationToken)
    {
        var Tercero = await _context.CntTerceros.FindAsync(request.Id);
        if (Tercero == null)
        {
            throw new Exception("No se encontro Tercero");
        }

        var tipoPersona = await _context.CntTipoPersonas.Where(p => p.Codigo == "N")
            .SingleOrDefaultAsync();
        if (tipoPersona == null)
        {
            throw new Exception("No se encontro tipo persona");
        }

        var responsabilidades = _context.cntResponsabilidadTerceros
            .Where(z => z.IdTercero == request.Id)
            .ToList();


        var segundoApellido = request.TerSegapellido.Trim() ?? "";
        var segundoNombre = request.TerSegnombre.Trim() ?? "";
        request.TerRazonsocial = request.TerPriapellido.Trim() + " " + segundoApellido + " " + request.TerPrinombre.Trim() + " " + segundoNombre.Trim();

        request.TerDigitoverificacion = _funciones.CalcularDigitoVerificacion(Tercero.TerDocumento);

        request.IdTippersona = tipoPersona.Id;
        request.IdGenero = request.IdGenero ?? Tercero.IdGenero;
        request.IdTipodocumento = request.IdTipodocumento ?? Tercero.IdTipodocumento;
        request.IdMunicipio = request.IdMunicipio ?? Tercero.IdMunicipio;
        request.IdRegimen = request.IdRegimen ?? Tercero.IdRegimen;
        request.IdCiiu = request.IdCiiu ?? Tercero.IdCiiu;
        //request.IdUsuario = request.IdUsuario;
        request.TerDocumento = request.TerDocumento ?? Tercero.TerDocumento;
        request.TerPrinombre = request.TerPrinombre ?? Tercero.TerPrinombre;
        request.TerPriapellido = request.TerPriapellido ?? Tercero.TerPriapellido;


        var transaction = _context.Database.BeginTransaction();
        try
        {

            var entidadDto = _mapper.Map<EditarTerceroModel, CntTercero>(request, Tercero);

            _context.RemoveRange(responsabilidades);
            if (request.ResponsabilidadTerceroModel != null)
            {

                var idResponsabilidades = (from num in request.ResponsabilidadTerceroModel select num.IdResponsabilidad).Distinct().ToList();

                EditarResponsabilidadTerceroModel registro = new EditarResponsabilidadTerceroModel();

                // Agregar los registros que vienen del request 
                foreach (int idResponsabilidad in idResponsabilidades)
                {
                    registro.IdResponsabilidad = idResponsabilidad;
                    registro.IdTercero = request.Id;

                    var responsabilidad = await _context.cntResponsabilidades.FindAsync(registro.IdResponsabilidad);
                    if (responsabilidad == null)
                    {
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
            throw new Exception("No se realizaron modificaciones el Tercero");
        }
        catch (Exception ex)
        {

            throw new Exception("Error al Editar Tercero catch " + ex.Message);
        }
    }
}