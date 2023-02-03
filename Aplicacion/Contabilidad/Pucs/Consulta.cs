using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.Models.Contabilidad.Pucs;
using AutoMapper;
using Dominio.Contabilidad;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Contabilidad.Pucs
{
    public class Consulta
    {
        public class ListaCntPucs : IRequest<List<ListarPucModel>>
        { }

        public class Manejador : IRequestHandler<ListaCntPucs, List<ListarPucModel>>
        {

            private readonly CntContext _context;
            private readonly IMapper mapper;
            public Manejador(CntContext context, IMapper mapper)
            {
                _context = context;
                this.mapper = mapper;
            }

            public async Task<List<ListarPucModel>> Handle(ListaCntPucs request, CancellationToken cancellationToken)
            {

                // var cntPucs = await _context.cntPucs
                // .ToListAsync();
                var entidadesDto = await _context.cntPucs
                .Include(x=>x.pucTipo)
                .Include(x=>x.tipoCuenta)
                .Select(p =>  mapper.Map<CntPuc,ListarPucModel>(p))
                .ToListAsync();


                

                 
                //var pucModel = mapper.Map<List<CntPuc>,List<ListarPucModel>>(pucs);
                //clase : primer digito
                //grupo: dos digitos
                //cuenta: cuatro digitos
                //subcuenta: seis digitos 

                foreach(var registro in entidadesDto)
                {
                        int longitud = registro.codigo.Length;
                        var codigoclase= registro.codigo.Substring(0, 1);
                        var clase = from regi  in entidadesDto
                                    where regi.codigo == codigoclase
                                    select new {nombre = regi.nombre};
                        registro.clase = clase.First().nombre;


                        var codigogrupo=    (longitud>1) ? registro.codigo.Substring(0, 2) : "";
                        if (longitud>1)
                        {
                            var grupo = from regi  in entidadesDto
                            where regi.codigo == codigogrupo
                            select new {nombre = regi.nombre};
                            registro.grupo = grupo.First().nombre;
                        } else {registro.grupo="";}
                            
                        var codigocuenta=   (longitud>3) ? registro.codigo.Substring(0, 4) : "";
                        if (longitud>3)
                        {   var cuenta = from regi  in entidadesDto
                            where regi.codigo == codigocuenta
                            select new {nombre = regi.nombre};
                            registro.cuenta = cuenta.First().nombre;
                        } else {registro.cuenta="";}
                        
                        var codigosubcuenta=(longitud>5) ? registro.codigo.Substring(0, 6) : "";
                        if (longitud>5)
                        {    
                            var subcuenta = from regi  in entidadesDto
                            where regi.codigo == codigosubcuenta
                            select new {nombre = regi.nombre};
                            registro.subcuenta = subcuenta.First().nombre;
                        } else {registro.subcuenta="";}
                        
                }
             
                return entidadesDto;

            }
        }



    }
}