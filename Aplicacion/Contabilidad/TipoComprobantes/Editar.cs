using Persistencia;
using System;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;
using Aplicacion.Models.Contabilidad.TipoComprobantes;
using AutoMapper;
using Dominio.Contabilidad;

namespace Aplicacion.Contabilidad.TipoComprobantes;

public class Editar
{
    public class Ejecuta : EditarTipoComprobanteModel, IRequest
    {



    }


    public class EjecutaValidador : AbstractValidator<Ejecuta>
    {
        public EjecutaValidador()
        {

            RuleFor(x => x.IdCategoriacomprobante).NotEmpty();
            RuleFor(x => x.Codigo).NotEmpty();
            RuleFor(x => x.Nombre).NotEmpty();
            RuleFor(x => x.TcoIncremento).NotEmpty();
            RuleFor(x => x.TcoIncremento).Matches("^[A,U,M]+");

            // RuleFor(x=>x.Editable).NotEmpty();
            // RuleFor(x=>x.Anulable).NotEmpty();
            RuleFor(x => x.IdUsuario).NotEmpty();

        }
    }


    public class Manejador : IRequestHandler<Ejecuta>
    {

        private CntContext _context;
        private readonly IMapper _mapper;

        public Manejador(CntContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
        {

            var entidad = await _context.cntTipoComprobantes.FindAsync(request.Id);
            if (entidad == null)
            {
                throw new Exception("Registro no encontrado");
            };

            var entidadDto = _mapper.Map<EditarTipoComprobanteModel, CntTipoComprobante>(request, entidad);
            var resultado = await _context.SaveChangesAsync();
            if (resultado > 0)
            {
                return Unit.Value;
            }

            throw new Exception("Error al modificar registro");

        }
    }

}