using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Municipios;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Municipios;

public class Consulta
{
    public class ListarMunicipios : IRequest<List<MunicipioModel>> { }

    public class Manejador : IRequestHandler<ListarMunicipios, List<MunicipioModel>>
    {
        private readonly CntContext _context;
        private readonly IMapper _mapper;

        public Manejador(CntContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<MunicipioModel>> Handle(ListarMunicipios request, CancellationToken cancellationToken)
        {
            var listarMunicipios = await _context.CntMunucipios
                                    .Include(d => d.Departamento)
                                    .ToListAsync();
            var listarMunicipiosModel = _mapper.Map<List<CntMunicipio>, List<MunicipioModel>>(listarMunicipios);

            return listarMunicipiosModel;
        }
    }

}