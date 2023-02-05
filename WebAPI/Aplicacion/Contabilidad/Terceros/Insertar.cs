using System;
using System.Linq;
using System.Text.Json;
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

public class InsertarTerceroRequest : InsertarTerceroModel, IRequest
{

}

public class InsertarTerceroValidator : AbstractValidator<InsertarTerceroRequest>
{
    public InsertarTerceroValidator()
    {
        RuleFor(x => x.IdTipodocumento).NotEmpty();
        RuleFor(x => x.TerDocumento).NotEmpty();
        RuleFor(x => x.IdUsuario).NotEmpty();
        RuleFor(x => x.IdTippersona).NotEmpty();
        RuleFor(x => x.IdGenero).NotEmpty();
        RuleFor(x => x.IdMunicipio).NotEmpty();
        RuleFor(x => x.TerPriapellido).NotEmpty();
        RuleFor(x => x.TerPrinombre).NotEmpty();
        RuleFor(x => x.ResponsabilidadTerceroModel).NotEmpty();
    }
}

public class InsertarTerceroHandler : IRequestHandler<InsertarTerceroRequest>
{
    public readonly CntContext _context;
    private readonly IMapper _mapper;
    private readonly IFunciones _funciones;


    public InsertarTerceroHandler(CntContext context, IMapper mapper, IFunciones funciones)
    {
        _context = context;
        _mapper = mapper;
        _funciones = funciones;
    }

    //List<int> distinct = list.Distinct().ToList();     


    //TODO:AGGD - VALLIDAR QUE NO RECIBIR EL MISMO Id RESPONSABILIDAD VARIAS VECES
    public async Task<Unit> Handle(InsertarTerceroRequest request, CancellationToken cancellationToken)
    {
        var segundoApellido = request.TerSegapellido.Trim() ?? "";
        var segundoNombre = request.TerSegnombre.Trim() ?? "";
        request.TerDigitoverificacion = _funciones.CalcularDigitoVerificacion(request.TerDocumento);
        request.TerRazonsocial = request.TerPriapellido.Trim() + " " + segundoApellido + " " + request.TerPrinombre.Trim() + " " + segundoNombre.Trim();

        var transaction = _context.Database.BeginTransaction();
        try
        {
            var terceroDto = _mapper.Map<InsertarTerceroModel, CntTercero>(request);
            await _context.CntTerceros.AddAsync(terceroDto);
            var valor = await _context.SaveChangesAsync();
            var idTercero = terceroDto.Id;

            if (request.ResponsabilidadTerceroModel == null)
            {
                //TODO:AGGD - VALIDAR QUE ENVIE MINIMO NO RESPONSABLE
            }


            if (request.ResponsabilidadTerceroModel != null)
            {

                var idResponsabilidades = (from num in request.ResponsabilidadTerceroModel select num.IdResponsabilidad).Distinct().ToList();

                InsertarResponsabilidadTerceroModel registro = new InsertarResponsabilidadTerceroModel();

                // Agregar los registros que vienen del request 
                //foreach (InsertarResponsabilidadTerceroModel registro in request.ResponsabilidadTerceroModel)
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