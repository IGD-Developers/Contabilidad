using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.CategoriaComprobantes;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.CategoriaComprobantes;

public class ConsultaId
{
    public class ConsultarId : IdCategoriaModel, IRequest<ListarCategoriaComprobantesModel>
    { }

    public class Manejador : IRequestHandler<ConsultarId, ListarCategoriaComprobantesModel>
    {
        private CntContext _context;
        private readonly IMapper _mapper;

        public Manejador(CntContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ListarCategoriaComprobantesModel> Handle(ConsultarId request, CancellationToken cancellationToken)
        {
            var entidad = await _context.cntCategoriaComprobantes
                .Include(c => c.CategoriaTipoComprobantes)
                .SingleOrDefaultAsync(i => i.Id == request.Id);
            if (entidad == null)
            {
                throw new Exception("Registro no encontrado");
            };

            var entidadDto = _mapper.Map<CntCategoriaComprobante, ListarCategoriaComprobantesModel>(entidad);

            return entidadDto;

        }
    }


}