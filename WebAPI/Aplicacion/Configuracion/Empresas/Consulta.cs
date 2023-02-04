using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using System.Linq;
using ContabilidadWebAPI.Dominio.Configuracion;
using ContabilidadWebAPI.Persistencia;
using ContabilidadWebAPI.Aplicacion.Models.Configuracion.Empresas;

namespace ContabilidadWebAPI.Aplicacion.Configuracion.Empresas;

public class Consulta
{

    public class ListaCnfEmpresas : IRequest<List<ListarEmpresasModel>>
    {

    }

    public class Manejador : IRequestHandler<ListaCnfEmpresas, List<ListarEmpresasModel>>
    {
        private readonly CntContext _context;
        private readonly IMapper _mapper;



        public Manejador(CntContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;



        }

        public async Task<List<ListarEmpresasModel>> Handle(ListaCnfEmpresas request, CancellationToken cancellationToken)
        {

            var entidades = await _context.cnfEmpresas
            .Include(t => t.TerceroEmpresa)
            .ToListAsync();

            var entidadesDto = _mapper.Map<List<CnfEmpresa>, List<ListarEmpresasModel>>(entidades);

            return entidadesDto;

        }


    }

}