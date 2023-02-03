using System.Threading;
using System.Threading.Tasks;
using MediatR;
using System;
using Persistencia;
using FluentValidation;
using Aplicacion.Models.Contabilidad.NotaAclaratoria;
using AutoMapper;
using Dominio.Contabilidad;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Contabilidad.NotaAclaratorias
{
    public class Editar
    {
        public class Ejecuta : EditarNotaAclaratoriaModel, IRequest{
        }

         public class EjecutaValidador : AbstractValidator<Ejecuta>
        {
            public EjecutaValidador()
            {
               /*  RuleFor(x=>x.Id).NotEmpty(); */
                RuleFor(x=>x.NacFecha).NotEmpty();
                RuleFor(x=>x.IdNotaaclaratoriatipo).NotEmpty();
                RuleFor(x=>x.IdPuc).NotEmpty();
                RuleFor(x=>x.NacTitulo).NotEmpty();
                RuleFor(x=>x.NacDetalle).NotEmpty();
                RuleFor(x=>x.IdUsuario).NotEmpty();

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
                var nota = await _context.cntNotaAclaratorias
                .Where(y => y.Estado == "A")
                .SingleOrDefaultAsync(y => y.Id == request.Id);

                if(nota==null){
                    throw new Exception("No se encontro nota Aclaratoria o su Estado no es activo");
                }

                var notaTipo = await _context.cntNotaAclaratoriaTipos.FindAsync(request.IdNotaaclaratoriatipo);
                if(notaTipo == null){
                    throw new Exception("Tipo de nota Aclaratoria no existe");
                }

                var codCuenta = await _context.cntPucs.FindAsync(request.IdPuc);
                if(codCuenta == null){
                    throw new Exception("Codigo de Cuenta no existe en el puc");
                }

                request.NacFecha = request.NacFecha ?? nota.NacFecha;
                request.IdNotaaclaratoriatipo = request.IdNotaaclaratoriatipo ?? nota.IdNotaaclaratoriatipo;
                request.NacTitulo = request.NacTitulo ?? nota.NacTitulo;
                request.NacDetalle = request.NacDetalle ?? nota.NacDetalle;
                request.IdUsuario = request.IdUsuario;

                var notaModel = _mapper.Map<EditarNotaAclaratoriaModel, CntNotaAclaratoria>(request, nota);

                try {

                    var resultado = await _context.SaveChangesAsync();
    
                    if(resultado>0){
                        return Unit.Value;
                    }
    
                    throw new Exception("No se pudo editar la nota");

                } catch (SystemException e) {
                    throw new Exception("Se encontro un error al editar cath ", e);
                }

                
            }
        }
    }
}