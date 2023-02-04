using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.ResponsabilidadTercero;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Persistencia;
using MediatR;

namespace ContabilidadWebAPI.Aplicacion.Contabilidad.ResponsabilidadTerceros;

public class ConsultaId
{
    public class ConsultarId : IRequest<ResponsabilidadTerceroModel>
    {
        public int Id;
    }

    public class Manejador : IRequestHandler<ConsultarId, ResponsabilidadTerceroModel>
    {
        private readonly CntContext _context;
        private readonly IMapper _mapper;

        public Manejador(CntContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponsabilidadTerceroModel> Handle(ConsultarId request, CancellationToken cancellationToken)
        {
            var consulta = await _context.cntResponsabilidadTerceros.FindAsync(request.Id);

            if (consulta == null)
            {
                throw new Exception("Responsabilidad Tercero consultada no se encontro");
            }

            var consultaModel = _mapper.Map<CntResponsabilidadTer, ResponsabilidadTerceroModel>(consulta);

            return consultaModel;
        }
    }
}