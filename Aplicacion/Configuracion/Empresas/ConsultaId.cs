using MediatR;
using Persistencia;
using System.Threading.Tasks;
using System.Threading;
using Dominio.Configuracion;
using System;
using Aplicacion.Models.Configuracion.Empresas;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace Aplicacion.Configuracion.Empresas
{
    public class ConsultaId
    {

        public class ConsultarId : IdEmpresasModel, IRequest<ListarEmpresasModel>
        {  }

        public class Manejador : IRequestHandler<ConsultarId, ListarEmpresasModel>
        {

            private readonly CntContext _context;
            private readonly IMapper _mapper;



            public Manejador(CntContext context,IMapper mapper)
            {
                _context = context;
                _mapper = mapper;            }

            public async Task<ListarEmpresasModel> Handle(ConsultarId request, CancellationToken cancellationToken)
            {


                 var entidad = await _context.cnfEmpresas
                 .Include(t=> t.TerceroEmpresa)
                 .SingleOrDefaultAsync(i => i.Id == request.Id);
               
                 //.FindAsync(request.Id);
               
                if (entidad == null) {
                     throw new Exception("Registro no encontrado");
                 };
                 var entidadDto = _mapper.Map<CnfEmpresa,ListarEmpresasModel>(entidad);
                 return entidadDto;


                // return empresa;

            }
        }



    }
}