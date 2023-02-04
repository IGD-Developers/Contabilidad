using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Responsabilidad;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Responsabilidades;

public class Consulta
{
    public class ListarResponsabilidades : IRequest<List<ResponsabilidadModel>> { }

    public class Manejador : IRequestHandler<ListarResponsabilidades, List<ResponsabilidadModel>>
    {
        private readonly CntContext _context;
        private readonly IMapper _mapper;

        public Manejador(CntContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ResponsabilidadModel>> Handle(ListarResponsabilidades request, CancellationToken cancellationToken)
        {
            var responsabilidades = await _context.cntResponsabilidades.ToListAsync();
            var responsabilidadesModel = _mapper.Map<List<CntResponsabilidad>, List<ResponsabilidadModel>>(responsabilidades);

            return responsabilidadesModel;
        }


    }
}