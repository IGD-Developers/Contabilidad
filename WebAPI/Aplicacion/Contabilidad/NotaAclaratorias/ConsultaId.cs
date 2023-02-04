
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.NotaAclaratoria;
using ContabilidadWebAPI.Persistencia;
using ContabilidadWebAPI.Dominio.Contabilidad;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.NotaAclaratorias;

public class ConsultaId
{

    public class ConsultarId : IRequest<ListarNotaAclaratoriaModel>
    {
        public int Id { get; set; }
    }

    public class Manejador : IRequestHandler<ConsultarId, ListarNotaAclaratoriaModel>
    {

        private readonly CntContext _context;
        private readonly IMapper _mapper;

        public Manejador(CntContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ListarNotaAclaratoriaModel> Handle(ConsultarId request, CancellationToken cancellationToken)
        {
            var notaAclaratoria = await _context.cntNotaAclaratorias
            .Include(t => t.NotaAclaratoriaTipo)
            .Include(c => c.CntPuct)
            .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (notaAclaratoria == null)
            {
                throw new Exception("NOTA ACLARATORIA NO EXISTE");
            }

            var notaAclaratoriasModel = _mapper.Map<CntNotaAclaratoria, ListarNotaAclaratoriaModel>(notaAclaratoria);

            return notaAclaratoriasModel;
        }
    }

}