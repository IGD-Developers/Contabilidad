using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.NotaAclaratoria;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.NotaAclaratorias;

public class Consulta


//DESDE IMediaTr
// Necesita dos clases 
//UNA que herede de IRequest y  
//OTRA como manejador de la Clase que HEREDE DE IRequestHandler 
//que maneja la LOGICA DE NEGOCIOS 
{
    public class ListaCntNotaAclaratorias : IRequest<List<ListarNotaAclaratoriaModel>>
    {


    }

    //El manejador necesita dos parametros:
    //la primera Clase de lista:  Formato en que lo vamos a devolver, tipo de dato
    public class Manejador : IRequestHandler<ListaCntNotaAclaratorias, List<ListarNotaAclaratoriaModel>>
    {

        private readonly CntContext _context;
        private readonly IMapper _mapper;

        public Manejador(CntContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ListarNotaAclaratoriaModel>> Handle(ListaCntNotaAclaratorias request, CancellationToken cancellationToken)
        {

            var notaAclaratorias = await _context.cntNotaAclaratorias
                .Include(t => t.NotaAclaratoriaTipo)
                .Include(p => p.CntPuct)
                .Where(n => n.Estado == "A")
                .ToListAsync();

            var notaAclaratoriasModel = _mapper.Map<List<CntNotaAclaratoria>, List<ListarNotaAclaratoriaModel>>(notaAclaratorias);

            return notaAclaratoriasModel;

        }
    }
}