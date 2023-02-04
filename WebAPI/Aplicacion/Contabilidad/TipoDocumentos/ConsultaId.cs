using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.TipoDocumento;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using MediatR;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.TipoDocumentos;

public class ConsultaId
{
    public class ConsultarTipoDocumentoId : IRequest<TipoDocumentoModel>
    {
        public int Id { get; set; }
    }

    public class Manejador : IRequestHandler<ConsultarTipoDocumentoId, TipoDocumentoModel>
    {
        private readonly CntContext _context;
        private readonly IMapper _mapper;
        public Manejador(CntContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<TipoDocumentoModel> Handle(ConsultarTipoDocumentoId request, CancellationToken cancellationToken)
        {
            var tipoDocumento = await _context.CntTipoDocumentos.FindAsync(request.Id);

            if (tipoDocumento == null)
                throw new Exception("Tipo Documento Consultado no Existe");

            var TipoDocumentoModel = _mapper.Map<CntTipoDocumento, TipoDocumentoModel>(tipoDocumento);
            return TipoDocumentoModel;
        }
    }
}