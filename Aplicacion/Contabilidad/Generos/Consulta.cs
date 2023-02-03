using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.Models.Contabilidad.Genero;
using AutoMapper;
using Dominio.Contabilidad;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Contabilidad.Generos;

public class Consulta
{
    public class ListaGeneros : IRequest<List<GeneroModel>>{}

    public class Manejador : IRequestHandler<ListaGeneros, List<GeneroModel>>
    {
        private readonly CntContext _context;
        private readonly IMapper _mapper;

        public Manejador(CntContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GeneroModel>> Handle(ListaGeneros request, CancellationToken cancellationToken)
        {
            var listaGeneros = await _context.CntGeneros.ToListAsync();
            var listaGenerosModel = _mapper.Map<List<CntGenero>, List<GeneroModel>>(listaGeneros);
            return listaGenerosModel;
        }
    }

}