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
            RuleFor(x => x.Codigo).NotEmpty();
            RuleFor(x => x.Nombre).NotEmpty();
            RuleFor(x => x.IdPuctipo).NotEmpty();
            //RuleFor(x => x.IdTipocuenta).NotEmpty();
            RuleFor(x => x.PacActiva).Must(x => x == false || x == true);
            RuleFor(x => x.PacBase).Must(x => x == false || x == true);
            RuleFor(x => x.PacAjusteniif).Must(x => x == false || x == true);
            //RuleFor(x => x.PacActiva).NotEmpty();
            //RuleFor(x => x.PacBase).NotEmpty();
            //RuleFor(x => x.PacAjusteniif).NotEmpty();
            //RuleFor(x => x.IdUsuario).NotEmpty();


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
            //Clase : primer digito
            //Grupo: dos digitos
            //Cuenta: cuatro digitos
            //SubCuenta: seis digitos 
            //auxiliar: ocho digitos 


            var tipoCuentas = await _context.cntTipoCuentas.ToListAsync();
            int longitud = request.Codigo.Length;
            if (longitud == 1)
            {
                 var idClase= tipoCuentas
                    .Where(t => t.Codigo == "CLA")
                    .Select(t=>new IdPucModel(){Id=t.Id}).SingleOrDefault();
                request.IdTipocuenta=idClase.Id;    
            
            }
            else if (longitud == 2)
            {
                 var idClase= tipoCuentas
                    .Where(t => t.Codigo == "GRU")
                    .Select(t=>new IdPucModel(){Id=t.Id}).SingleOrDefault();
                request.IdTipocuenta=idClase.Id;    
            }
            else if (longitud == 4)
            {
                 var idClase= tipoCuentas
                    .Where(t => t.Codigo == "CUE")
                    .Select(t=>new IdPucModel(){Id=t.Id}).SingleOrDefault();
                request.IdTipocuenta=idClase.Id;    

            }

            else if (longitud == 6)
            {
                 var idClase= tipoCuentas
                    .Where(t => t.Codigo == "SUB")
                    .Select(t=>new IdPucModel(){Id=t.Id}).SingleOrDefault();
                request.IdTipocuenta=idClase.Id;    

            }
            else if (longitud == 8)
            {
                 var idClase= tipoCuentas
                    .Where(t => t.Codigo == "AUX")
                    .Select(t=>new IdPucModel(){Id=t.Id}).SingleOrDefault();
                request.IdTipocuenta=idClase.Id;    

            }
            else
            { throw new Exception("Error: Longitud de Cuenta incorrecta"); }




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