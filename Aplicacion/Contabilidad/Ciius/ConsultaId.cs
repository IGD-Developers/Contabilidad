using System;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.Models.Contabilidad.Ciius;
using AutoMapper;
using Dominio.Contabilidad;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Contabilidad.Ciius;

public class ConsultaId
{
    public class ConsultarId : IRequest<CiiuModel>{
        public int Id {get; set;}
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
            .Include(x=>x.ciiuSeccionCiiu)
            .Include(x=>x.ciiuTipoCiiu)
            .FirstOrDefaultAsync(x=>x.id == request.Id);

            if(ciiusId==null){
                throw new Exception("CIIUS Consultado no Existe");
            }

            var ciiusIdModel = _mapper.Map<CntCiiu, CiiuModel>(ciiusId);
            return ciiusIdModel;
        }
    }

}