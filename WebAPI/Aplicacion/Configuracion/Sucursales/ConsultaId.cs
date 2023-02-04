using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ContabilidadWebAPI.Aplicacion.Models.Configuracion.Sucursales;
using ContabilidadWebAPI.Persistencia;
using ContabilidadWebAPI.Dominio.Configuracion;

namespace ContabilidadWebAPI.Aplicacion.Configuracion.Sucursales;

public class ConsultaId
{
    public class ConsultarId : IdSucursalModel, IRequest<ListarSucursalModel>
    { }

    public class Manejador : IRequestHandler<ConsultarId, ListarSucursalModel>
    {

        private CntContext _context;

        private readonly IMapper _mapper;



        public Manejador(CntContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }


        public async Task<ListarSucursalModel> Handle(ConsultarId request, CancellationToken cancellationToken)
        {

            var entidad = await _context.cnfSucursales
            .Include(e => e.Empresa)
            .SingleOrDefaultAsync(i => i.Id == request.Id);


            if (entidad == null)
            {
                throw new Exception("Registro no encontrado");
            };
            var entidadDto = _mapper.Map<CnfSucursal, ListarSucursalModel>(entidad);

            return entidadDto;


        }
    }

}