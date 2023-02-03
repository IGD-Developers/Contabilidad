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
                .Include(x=>x.PucTipo)
                .Include(x=>x.TipoCuenta)
                .Select(p =>  mapper.Map<CntPuc,ListarPucModel>(p))
                .ToListAsync();


                

                 
                //var PucModel = mapper.Map<List<CntPuc>,List<ListarPucModel>>(pucs);
                //Clase : primer digito
                //Grupo: dos digitos
                //Cuenta: cuatro digitos
                //SubCuenta: seis digitos 

                foreach(var registro in entidadesDto)
                {
                        int longitud = registro.Codigo.Length;
                        var codigoclase= registro.Codigo.Substring(0, 1);
                        var Clase = from regi  in entidadesDto
                                    where regi.Codigo == codigoclase
                                    select new {Nombre = regi.Nombre};
                        registro.Clase = Clase.First().Nombre;


                        var codigogrupo=    (longitud>1) ? registro.Codigo.Substring(0, 2) : "";
                        if (longitud>1)
                        {
                            var Grupo = from regi  in entidadesDto
                            where regi.Codigo == codigogrupo
                            select new {Nombre = regi.Nombre};
                            registro.Grupo = Grupo.First().Nombre;
                        } else {registro.Grupo="";}
                            
                        var codigocuenta=   (longitud>3) ? registro.Codigo.Substring(0, 4) : "";
                        if (longitud>3)
                        {   var Cuenta = from regi  in entidadesDto
                            where regi.Codigo == codigocuenta
                            select new {Nombre = regi.Nombre};
                            registro.Cuenta = Cuenta.First().Nombre;
                        } else {registro.Cuenta="";}
                        
                        var codigosubcuenta=(longitud>5) ? registro.Codigo.Substring(0, 6) : "";
                        if (longitud>5)
                        {    
                            var SubCuenta = from regi  in entidadesDto
                            where regi.Codigo == codigosubcuenta
                            select new {Nombre = regi.Nombre};
                            registro.SubCuenta = SubCuenta.First().Nombre;
                        } else {registro.SubCuenta="";}
                        
                }
             
                return entidadesDto;

            }
        }



    }
}