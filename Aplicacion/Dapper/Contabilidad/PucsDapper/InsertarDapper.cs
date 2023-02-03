using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Persistencia.DapperConexion.Contabilidad.Pucs;

namespace Aplicacion.Dapper.Contabilidad.PucsDapper;

public class InsertarDapper
{

    public class Ejecuta: IRequest {

    public string codigo { get; set; }
    public string nombre { get; set; }
    public int? id_puctipo { get; set; }
    public int? id_tipocuenta { get; set; }
    public bool pac_activa { get; set; }
    public bool pac_base { get; set; }
    public bool pac_ajusteniif { get; set; }
    
    public string id_usuario { get; set; }
    }
    
 public class EjecutaValidador : AbstractValidator<Ejecuta>
    {
        public EjecutaValidador()
        {

            RuleFor(x=>x.codigo).NotEmpty();
            RuleFor(x=>x.nombre).NotEmpty();
            RuleFor(x=>x.id_tipocuenta).NotEmpty();
            // RuleFor(x=>x.pac_activa).NotEmpty();
            // RuleFor(x=>x.pac_base).NotEmpty();
            // RuleFor(x=>x.pac_ajusteniif).NotEmpty();
            RuleFor(x=>x.id_usuario).NotEmpty();

    
        }
    }


    public class Manejador : IRequestHandler<Ejecuta>
    {

        private readonly IPucRepositorio _pucRepositorio;

        public Manejador(IPucRepositorio pucRepositorio)
        {
            _pucRepositorio = pucRepositorio;
        }

        public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
        {

            PucRepositorioModel  modelo = new PucRepositorioModel {
                codigo =request.codigo,
                nombre =request.nombre,
                id_puctipo =request.id_puctipo,
                id_tipocuenta =request.id_tipocuenta,
                pac_activa=request.pac_activa,
                pac_base= request.pac_base,
                pac_ajusteniif=request.pac_ajusteniif,
                id_usuario=request.id_usuario
            }; 
            
            var resultado = await _pucRepositorio.Insertar(modelo);
             if (resultado >0) {
            return Unit.Value;
        }

        throw new Exception("Error al registrar cuenta");
        }
    }

}

