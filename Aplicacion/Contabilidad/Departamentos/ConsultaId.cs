using System;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.Models.Contabilidad.Departamentos;
using AutoMapper;
using Dominio.Contabilidad;
using MediatR;
using Persistencia;

namespace Aplicacion.Contabilidad.Departamentos;

public class ConsultaId
{
    //TODO:AGGD-ACTUALIZAR
    public class ConsultarId : IRequest<DepartamentosModel>{
        public int Id {get; set;}
    }

    public class Manejador : IRequestHandler<ConsultarId, DepartamentosModel>
    {
        private readonly CntContext _context;
        private readonly IMapper _mapper;

        public Manejador(CntContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DepartamentosModel> Handle(ConsultarId request, CancellationToken cancellationToken)
        {
            var departamentos = await _context.CntDepartamentos.FindAsync(request.Id);

            if(departamentos == null){
                throw new Exception("Departamento Consultado no Existe");
            }

            var DepartamentosModel = _mapper.Map<CntDepartamento, DepartamentosModel>(departamentos);
            return DepartamentosModel;
        }
    }
}