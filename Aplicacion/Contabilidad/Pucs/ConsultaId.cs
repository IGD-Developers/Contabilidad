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
                
                //var PucModel =  mapper.Map<CntPuc, ListarPucModel>(puc);

                var longitud    = entidadDto.Codigo.Length;
                var codigoclase = entidadDto.Codigo.Substring(0, 1);
                var codigogrupo = (longitud>1) ? entidadDto.Codigo.Substring(0, 2) : "";
                var codigocuenta= (longitud>3) ? entidadDto.Codigo.Substring(0, 4) : "";
                var codigosubcuenta=(longitud>5) ? entidadDto.Codigo.Substring(0, 6) : "";


                var Clase = await context.cntPucs
                                    .Where(p=>p.Codigo == codigoclase)
                                    .Select(c=> new NombreModel{Nombre=c.Nombre})
                                    .SingleOrDefaultAsync(); 
                entidadDto.Clase = Clase.Nombre;    

                if (longitud>1)
                {
                    var Grupo = await context.cntPucs
                        .Where(p=>p.Codigo == codigogrupo)
                        .Select(c=> new NombreModel{Nombre=c.Nombre})
                        .SingleOrDefaultAsync(); 
                        entidadDto.Grupo = Grupo.Nombre;    
                } else {entidadDto.Grupo ="";}
                            
                        
                if (longitud>3)
                {
                    var Cuenta = await context.cntPucs
                        .Where(p=>p.Codigo == codigocuenta)
                        .Select(c=> new NombreModel{Nombre=c.Nombre})
                        .SingleOrDefaultAsync(); 
                    entidadDto.Cuenta = Cuenta.Nombre;   
                } else {entidadDto.Cuenta="";}
            
            
                if (longitud>5)
                {    
                    var SubCuenta = await context.cntPucs
                        .Where(p=>p.Codigo == codigosubcuenta)
                        .Select(c=> new {Nombre=c.Nombre})
                        .SingleOrDefaultAsync(); 
                    entidadDto.SubCuenta = SubCuenta.Nombre;   
                } else {entidadDto.SubCuenta="";}     

              return entidadDto;
            }
        }
    }
}