using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.CuentaImpuestos;
using ContabilidadWebAPI.Persistencia;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.CuentaImpuestos;

public class ConsultaId
{

    public class ConsultarId : IdCuentaImpuestoModel, IRequest<ListarCuentaImpuestosModel>
    { }

    public class Manejador : IRequestHandler<ConsultarId, ListarCuentaImpuestosModel>
    {
        private CntContext _context;

        private readonly IMapper _mapper;



        public Manejador(CntContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ListarCuentaImpuestosModel> Handle(ConsultarId request, CancellationToken cancellationToken)
        {

            var entidadDto = await _context.cntCuentaImpuestos
                                    .Include(p => p.Puc)
                                    .Include(p => p.TipoImpuesto)
                                    .Where(p => p.Id == request.Id)
                                    .Select(p => _mapper.Map<CntCuentaImpuesto, ListarCuentaImpuestosModel>(p))
                                    .SingleOrDefaultAsync();


            if (entidadDto == null)
            {
                throw new Exception("Registro no encontrado");
            };
            //var entidadDto = _mapper.Map<CntCuentaImpuesto, ListarCuentaImpuestosModel>(entidad);
            return entidadDto;


        }
    }

}