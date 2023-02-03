using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistencia.DapperConexion.Contabilidad.Pucs;

namespace Aplicacion.Dapper.Contabilidad.PucsDapper;

public class ConsultaDapper
{

     
    public class Lista: IRequest<List<PucRepositorioModel>> {}

    public class Manejador : IRequestHandler<Lista, List<PucRepositorioModel>>
    {
        private readonly IPucRepositorio _pucRepositorio;

        public Manejador(IPucRepositorio pucRepositorio)
        {
            _pucRepositorio = pucRepositorio;
        }

        public async Task<List<PucRepositorioModel>> Handle(Lista request, CancellationToken cancellationToken)
        {
            var resultado =  await _pucRepositorio.ObtenerLista();
            //IEnumerable resultado lo llevamos a ToList() Para concordar con el Controller
            return resultado.ToList();
        }
    }
}
    

