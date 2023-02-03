using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.Models.Contabilidad.CuentaImpuestos;
using AutoMapper;
using Dominio.Contabilidad;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Contabilidad.CuentaImpuestos;



public class Consulta
{


    public class ListaCntCuentaImpuestos : IRequest<List<ListarCuentaImpuestosModel>>
    {  }

    public class Manejador : IRequestHandler<ListaCntCuentaImpuestos, List<ListarCuentaImpuestosModel>>
    {


         private readonly CntContext _context;
        private readonly IMapper _mapper;
        public Manejador(CntContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ListarCuentaImpuestosModel>> Handle(ListaCntCuentaImpuestos request, CancellationToken cancellationToken)
        {
           
            var entidadesDto1 = await _context.cntCuentaImpuestos
                                .Include(p => p.puc)
                                .Include(p => p.tipoImpuesto)
                                .Select(p =>  _mapper.Map<CntCuentaImpuesto,ListarCuentaImpuestosModel>(p))
                                .ToListAsync();
            
            return entidadesDto1;
            
            // var entidades = await _context.cntCuentaImpuestos
            //                     .Include(p => p.puc)
            //                     .Include(ti => ti.tipoImpuesto)
            //                     .ToListAsync();
            // //var entidadesDto = _mapper.Map<List<CntCuentaImpuesto>, List<ListarCuentaImpuestosModel>>(entidades);


            // var entidades1 = await _context.cntCuentaImpuestos
            //                     .Include(p => p.puc)
            //                     .Include(p => p.tipoImpuesto)
            //                     .Select(p =>new  ListarCuentaImpuestosModel()
            //                     {
            //                         pucnombre =p.puc.nombre,
            //                         puccodigo =p.puc.codigo,
            //                         tipoimpuestonombre=p.tipoImpuesto.nombre,
            //                         tipoimpuestocodigo=p.tipoImpuesto.codigo
            //                     })
            //                     .ToListAsync();
            
            
        }
    }





}
