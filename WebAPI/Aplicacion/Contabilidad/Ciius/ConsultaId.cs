using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Ciius;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Ciius;

public class ConsultaId
{
    public class ConsultarId : IRequest<CiiuModel>
    {
        public int Id { get; set; }
    }

    public class Manejador : IRequestHandler<ConsultarId, CiiuModel>
    {
        private readonly CntContext _cntContext;
        private readonly IMapper _mapper;

        public Manejador(CntContext cntContext, IMapper mapper)
        {
            _cntContext = cntContext;
            _mapper = mapper;
        }

        public async Task<CiiuModel> Handle(ConsultarId request, CancellationToken cancellationToken)
        {
            var ciiusId = await _cntContext.CntCiius
            .Include(x => x.CiiuSeccionCiiu)
            .Include(x => x.CiiuTipoCiiu)
            .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (ciiusId == null)
            {
                throw new Exception("CIIUS Consultado no Existe");
            }

            var ciiusIdModel = _mapper.Map<CntCiiu, CiiuModel>(ciiusId);
            return ciiusIdModel;
        }
    }

}