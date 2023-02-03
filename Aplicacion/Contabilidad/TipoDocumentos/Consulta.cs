using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.Models.Contabilidad.TipoDocumento;
using AutoMapper;
using Dominio.Contabilidad;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Contabilidad.TipoDocumentos;

public class Consulta
{
    //Clase que representa lista de elementos a retornar desde la db
    public class ListaTipoDocumentos : IRequest<List<TipoDocumentoModel>>{}

    //Clase para manejar la logica de la operacion
    //(que va a devolver, formato)
    public class Manejador : IRequestHandler<ListaTipoDocumentos, List<TipoDocumentoModel>>
    {
        private readonly CntContext _context;
        private readonly IMapper _mapper;
        public Manejador(CntContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TipoDocumentoModel>> Handle(ListaTipoDocumentos request, CancellationToken cancellationToken)
        {
            var tipoDocumento = await _context.CntTipoDocumentos.ToListAsync();

            var tipodocumentoModel = _mapper.Map<List<CntTipoDocumento>, List<TipoDocumentoModel>>(tipoDocumento);
            
            return tipodocumentoModel;
        }
    }
}