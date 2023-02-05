using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Departamentos;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using MediatR;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Departamentos;

//TODO:AGGD-ACTUALIZAR
public class ConsultarDepartamentoRequest : IRequest<DepartamentosModel>
{
    public int Id { get; set; }
}

public class ConsultarDepartamentoHandler : IRequestHandler<ConsultarDepartamentoRequest, DepartamentosModel>
{
    private readonly CntContext _context;
    private readonly IMapper _mapper;

    public ConsultarDepartamentoHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<DepartamentosModel> Handle(ConsultarDepartamentoRequest request, CancellationToken cancellationToken)
    {
        var departamentos = await _context.CntDepartamentos.FindAsync(request.Id);

        if (departamentos == null)
        {
            throw new Exception("Departamento Consultado no Existe");
        }

        var DepartamentosModel = _mapper.Map<CntDepartamento, DepartamentosModel>(departamentos);
        return DepartamentosModel;
    }
}