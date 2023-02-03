
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.Models.Configuracion.Sucursales;
using AutoMapper;
using Dominio.Configuracion;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Configuracion.Sucursales
{

    public class Consulta
    {

        //Lista de objetos tipo IRequest envolviendo una lista de tipo CntCategoriaComprobante
        public class ListaCnfSucursales : IRequest<List<ListarSucursalModel>>
        {  }

        //Parametros: tipo de dato a devolver que es objeto IRequest ListaCntTipoComprobantes primera clase declarada,
        //el segundo pmt es el formato en que se devuelve que es un  List<CntTipoComprobante>

        public class Manejador : IRequestHandler<ListaCnfSucursales, List<ListarSucursalModel>>
        {
            private CntContext _context;
             private readonly IMapper _mapper;



            public Manejador(CntContext context,IMapper mapper)
            {
                _context = context;
                _mapper = mapper;

            }


            //La interfaz se autogenera -agregamos async
            //La interfaz consume el objeto de EF para devolver la lista de tipo de comprobantes 
            public async Task<List<ListarSucursalModel>> Handle(ListaCnfSucursales request, CancellationToken cancellationToken)
            {
                // El contexto devuelve desde el dbset

                var entidades = await _context.cnfSucursales
                .Include(e=>e.Empresa)
                .ToListAsync();

                var entidadesDto = _mapper.Map<List<CnfSucursal>,List<ListarSucursalModel>>(entidades);
                
                return entidadesDto;

            }
        }


    }
}