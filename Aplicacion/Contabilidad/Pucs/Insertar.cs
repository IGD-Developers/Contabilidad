using MediatR;
using Persistencia;
using Dominio.Contabilidad;
using System;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;
using Aplicacion.Models.Contabilidad.Pucs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Aplicacion.Contabilidad.Pucs;

public class Insertar
{
    public class Ejecuta : InsertarPucModel, IRequest
    { }


    public class EjecutaValidador : AbstractValidator<Ejecuta>
    {
        public EjecutaValidador()
        {
            RuleFor(x => x.codigo).NotEmpty();
            RuleFor(x => x.nombre).NotEmpty();
            RuleFor(x => x.id_puctipo).NotEmpty();
            //RuleFor(x => x.id_tipocuenta).NotEmpty();
            RuleFor(x => x.pac_activa).Must(x => x == false || x == true);
            RuleFor(x => x.pac_base).Must(x => x == false || x == true);
            RuleFor(x => x.pac_ajusteniif).Must(x => x == false || x == true);
            //RuleFor(x => x.pac_activa).NotEmpty();
            //RuleFor(x => x.pac_base).NotEmpty();
            //RuleFor(x => x.pac_ajusteniif).NotEmpty();
            //RuleFor(x => x.id_usuario).NotEmpty();


        }
    }

    public class Manejador : IRequestHandler<Ejecuta>
    {

        private readonly CntContext _context;
        private readonly IMapper _mapper;



        public Manejador(CntContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
        {
            //clase : primer digito
            //grupo: dos digitos
            //cuenta: cuatro digitos
            //subcuenta: seis digitos 
            //auxiliar: ocho digitos 


            var tipoCuentas = await _context.cntTipoCuentas.ToListAsync();
            int longitud = request.codigo.Length;
            if (longitud == 1)
            {
                 var idClase= tipoCuentas
                    .Where(t => t.codigo == "CLA")
                    .Select(t=>new IdPucModel(){Id=t.id}).SingleOrDefault();
                request.id_tipocuenta=idClase.Id;    
            
            }
            else if (longitud == 2)
            {
                 var idClase= tipoCuentas
                    .Where(t => t.codigo == "GRU")
                    .Select(t=>new IdPucModel(){Id=t.id}).SingleOrDefault();
                request.id_tipocuenta=idClase.Id;    
            }
            else if (longitud == 4)
            {
                 var idClase= tipoCuentas
                    .Where(t => t.codigo == "CUE")
                    .Select(t=>new IdPucModel(){Id=t.id}).SingleOrDefault();
                request.id_tipocuenta=idClase.Id;    

            }

            else if (longitud == 6)
            {
                 var idClase= tipoCuentas
                    .Where(t => t.codigo == "SUB")
                    .Select(t=>new IdPucModel(){Id=t.id}).SingleOrDefault();
                request.id_tipocuenta=idClase.Id;    

            }
            else if (longitud == 8)
            {
                 var idClase= tipoCuentas
                    .Where(t => t.codigo == "AUX")
                    .Select(t=>new IdPucModel(){Id=t.id}).SingleOrDefault();
                request.id_tipocuenta=idClase.Id;    

            }
            else
            { throw new Exception("Error: Longitud de cuenta incorrecta"); }




            var entidadDto = _mapper.Map<InsertarPucModel, CntPuc>(request);


            _context.cntPucs.Add(entidadDto);
            //TODO: MARIA LLave Duplicacada Codigo
            try
            {
                var respuesta = await _context.SaveChangesAsync();
                if (respuesta > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("Error al Insertar registro");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Insertar registro catch " + ex.Message);


            }
        }
    }


}