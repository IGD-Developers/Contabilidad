using MediatR;
using Persistencia;
using System.Threading.Tasks;
using System.Threading;
using Dominio.Contabilidad;
using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Aplicacion.Models.Contabilidad.Pucs;
using Aplicacion.Models.Contabilidad.LiquidaImpuestos;

namespace Aplicacion.Contabilidad.Pucs
{
    public class ConsultaId
    {

        public class ConsultarId : IdPucModel, IRequest<ListarPucModel>
        { }


        public class Manejador : IRequestHandler<ConsultarId, ListarPucModel>
        {

            private readonly CntContext context;
            private readonly IMapper mapper;

            public Manejador(CntContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }

            public async Task<ListarPucModel> Handle(ConsultarId request, CancellationToken cancellationToken)
            {

                var entidadDto = await context.cntPucs
                .Include(x=>x.PucTipo)
                .Include(x=>x.TipoCuenta)
                .Where(p=>p.Id == request.Id)
                .Select(p =>  mapper.Map<CntPuc, ListarPucModel>(p))
                .SingleOrDefaultAsync();


                


                if (entidadDto == null) {  
                    throw new Exception("Registro no encontrado");
                };     
                
                //var pucModel =  mapper.Map<CntPuc, ListarPucModel>(puc);

                var longitud    = entidadDto.codigo.Length;
                var codigoclase = entidadDto.codigo.Substring(0, 1);
                var codigogrupo = (longitud>1) ? entidadDto.codigo.Substring(0, 2) : "";
                var codigocuenta= (longitud>3) ? entidadDto.codigo.Substring(0, 4) : "";
                var codigosubcuenta=(longitud>5) ? entidadDto.codigo.Substring(0, 6) : "";


                var clase = await context.cntPucs
                                    .Where(p=>p.Codigo == codigoclase)
                                    .Select(c=> new nombreModel{nombre=c.Nombre})
                                    .SingleOrDefaultAsync(); 
                entidadDto.clase = clase.nombre;    

                if (longitud>1)
                {
                    var grupo = await context.cntPucs
                        .Where(p=>p.Codigo == codigogrupo)
                        .Select(c=> new nombreModel{nombre=c.Nombre})
                        .SingleOrDefaultAsync(); 
                        entidadDto.grupo = grupo.nombre;    
                } else {entidadDto.grupo ="";}
                            
                        
                if (longitud>3)
                {
                    var cuenta = await context.cntPucs
                        .Where(p=>p.Codigo == codigocuenta)
                        .Select(c=> new nombreModel{nombre=c.Nombre})
                        .SingleOrDefaultAsync(); 
                    entidadDto.cuenta = cuenta.nombre;   
                } else {entidadDto.cuenta="";}
            
            
                if (longitud>5)
                {    
                    var subcuenta = await context.cntPucs
                        .Where(p=>p.Codigo == codigosubcuenta)
                        .Select(c=> new {nombre=c.Nombre})
                        .SingleOrDefaultAsync(); 
                    entidadDto.subcuenta = subcuenta.nombre;   
                } else {entidadDto.subcuenta="";}     

              return entidadDto;
            }
        }
    }
}