using System.Collections.Generic;
using System.Threading;
using MediatR;
using Persistencia;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dominio.Contabilidad;
using Aplicacion.Models.Contabilidad.NotaAclaratoriaTipo;
using AutoMapper;

namespace Aplicacion.Contabilidad.NotaAclaratoriaTipos;

public class Consulta
{

    public class ListaCntNotaAclaratoriaTipos : IRequest<List<NotaAclaratoriaTipoModel>>
    {}

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