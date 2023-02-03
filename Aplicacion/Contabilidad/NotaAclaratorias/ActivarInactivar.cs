using System;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.Models.Contabilidad.NotaAclaratoria;
using AutoMapper;
using Dominio.Contabilidad;
using MediatR;
using Persistencia;

namespace Aplicacion.Contabilidad.NotaAclaratorias
{
    public class ActivarInactivar
    {
        public class Ejecuta : ActivarInactivarNotaAclaratoriaModel, IRequest{}

        public class Manejador : IRequestHandler<Ejecuta>
        {
            public readonly CntContext _context;
            public readonly IMapper _mapper;

            public Manejador(CntContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var nota = await _context.cntNotaAclaratorias.FindAsync(request.ID);

                if(nota == null){
                    throw new Exception("Nota Consultada no existe");
                }

                if(nota.Estado == "A"){
                    request.estado = "I";

                }else if(nota.Estado == "I"){
                    request.estado = "A";
                }

                try {
                    var notaModel = _mapper.Map<ActivarInactivarNotaAclaratoriaModel, CntNotaAclaratoria>(request, nota);
    
                    var resultado = await _context.SaveChangesAsync();
    
                    if(resultado>0){
                        return Unit.Value;
                    }
    
                    throw new Exception("No se pudo Cambiar estado a la nota aclaratoria");

                } catch (SystemException e) {
                    throw new Exception("Ocurrio un error inesperado al cambiar estado", e);
                    
                }




            }
        }
    }
}