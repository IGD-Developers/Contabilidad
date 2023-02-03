using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.Models.Contabilidad.Departamentos;
using AutoMapper;
using Dominio.Contabilidad;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Contabilidad.Departamentos
{
    public class Consulta
    {
        public class ListaDepartamentos : IRequest<List<DepartamentosModel>>{}

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
}