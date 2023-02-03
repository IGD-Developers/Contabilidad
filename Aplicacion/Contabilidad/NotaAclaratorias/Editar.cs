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
               /*  RuleFor(x=>x.ID).NotEmpty(); */
                RuleFor(x=>x.nac_fecha).NotEmpty();
                RuleFor(x=>x.id_notaaclaratoriatipo).NotEmpty();
                RuleFor(x=>x.id_puc).NotEmpty();
                RuleFor(x=>x.nac_titulo).NotEmpty();
                RuleFor(x=>x.nac_detalle).NotEmpty();
                RuleFor(x=>x.id_usuario).NotEmpty();

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
                .Where(y => y.estado == "A")
                .SingleOrDefaultAsync(y => y.id == request.ID);

                if(nota==null){
                    throw new Exception("No se encontro nota Aclaratoria o su estado no es activo");
                }

                var notaTipo = await _context.cntNotaAclaratoriaTipos.FindAsync(request.id_notaaclaratoriatipo);
                if(notaTipo == null){
                    throw new Exception("Tipo de nota Aclaratoria no existe");
                }

                var codCuenta = await _context.cntPucs.FindAsync(request.id_puc);
                if(codCuenta == null){
                    throw new Exception("Codigo de cuenta no existe en el puc");
                }

                request.nac_fecha = request.nac_fecha ?? nota.nac_fecha;
                request.id_notaaclaratoriatipo = request.id_notaaclaratoriatipo ?? nota.id_notaaclaratoriatipo;
                request.nac_titulo = request.nac_titulo ?? nota.nac_titulo;
                request.nac_detalle = request.nac_detalle ?? nota.nac_detalle;
                request.id_usuario = request.id_usuario;

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