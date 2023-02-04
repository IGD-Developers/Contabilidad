using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Departamentos;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Departamentos;

public class Consulta
{
    public class ListaDepartamentos : IRequest<List<DepartamentosModel>> { }

    public class Manejador : IRequestHandler<ListaDepartamentos, List<DepartamentosModel>>
    {
        public readonly CntContext _context;
        public readonly IMapper _mapper;
        public Manejador(CntContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;


        }

        public async Task<List<DepartamentosModel>> Handle(ListaDepartamentos request, CancellationToken cancellationToken)
        {
            var departamentos = await _context.CntDepartamentos.ToListAsync();
            var DepartamentosModel = _mapper.Map<List<CntDepartamento>, List<DepartamentosModel>>(departamentos);
            return DepartamentosModel;
        }
    }
}