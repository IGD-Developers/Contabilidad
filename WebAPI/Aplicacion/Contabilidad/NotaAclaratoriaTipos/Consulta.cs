using System.Collections.Generic;
using System.Threading;
using MediatR;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ContabilidadWebAPI.Persistencia;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.NotaAclaratoriaTipo;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.NotaAclaratoriaTipos;

public class Consulta
{

    public class ListaCntNotaAclaratoriaTipos : IRequest<List<NotaAclaratoriaTipoModel>>
    { }

    public class Manejador : IRequestHandler<ListaCntNotaAclaratoriaTipos, List<NotaAclaratoriaTipoModel>>
    {
        private CntContext _context;
        private IMapper _mapper;

        public Manejador(CntContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<NotaAclaratoriaTipoModel>> Handle(ListaCntNotaAclaratoriaTipos request, CancellationToken cancellationToken)
        {
            var notaAclaratoriaTipos = await _context.cntNotaAclaratoriaTipos.ToListAsync();

            var notaAclaratoriasTiposModel = _mapper.Map<List<CntNotaAclaratoriaTipo>, List<NotaAclaratoriaTipoModel>>(notaAclaratoriaTipos);

            return notaAclaratoriasTiposModel;

        }
    }




}